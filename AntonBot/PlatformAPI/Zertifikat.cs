using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace AntonBot.PlatformAPI
{
    class Zertifikat
    {
        public static void Install() {

            /*
            PowerShell ps = PowerShell.Create();
            ps.AddCommand("$cert = New-SelfSignedCertificate -DnsName @(\"localhost\", \"localhost\") -TextExtension @(\"127.0.0.1:8443 ={text}DNS = localhost & IPAddress = 127.0.0.1 & IPAddress =::1\") -CertStoreLocation \"cert:\\CurrentUser\\My\" -KeyUsage CertSign,CrlSign,DigitalSignature");
            ps.AddCommand("$certKeyPath = \"c:\\certs\\contoso.com.pfx\"" + Environment.NewLine +
"$password = ConvertTo - SecureString 'password' - AsPlainText - Force" + Environment.NewLine +
"$cert | Export - PfxCertificate - FilePath $certKeyPath - Password $password" + Environment.NewLine +
"$rootCert = $(Import - PfxCertificate - FilePath $certKeyPath - CertStoreLocation 'Cert:\\LocalMachine\\Root' - Password $password)");
            ps.Invoke();
            */
            string command = "openssl req - x509 -out localhost.crt - keyout localhost.key - newkey rsa: 2048 - nodes - sha256 - subj '/CN=localhost' - extensions EXT - config < (printf \"[dn]\nCN = localhost\n[req]\ndistinguished_name = dn\n[EXT]\nsubjectAltName = DNS:localhost\nkeyUsage = digitalSignature\nextendedKeyUsage = serverAuth";
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                Console.WriteLine(result);
            }
            catch (Exception objException)
            {
                // Log the exception
                Console.WriteLine(objException.Message);
            }
        }
    }
}
