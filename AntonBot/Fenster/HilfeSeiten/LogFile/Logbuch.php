<!DOCTYPE html>
<html>
<head>
    <title>Anzeige Logbuch</title>
    <link rel="icon" href="../PinguinServer.jpg" />
    <link rel="icon" href="../PinguinServer.jpg" />
    <link rel="stylesheet" href="../Style.css" />
    <meta charset="UTF-8">
    <style>
        .LogEintrag{
        text-align: left;
	    font-family: Verdana, sans-serif;
        background-color: gray;
        padding-top:5px;
        padding-bottom:5px;
        }
    </style>
</head>
<body>
    <div class="MenuLeiste">
        <ul>
            <li><a href="../Einrichtung/Index.html">Einrichtung</a></li>
            <li><a href="../Fenster/Index.html">Fenster</a></li>
            <li><a href="../LogFile/Index.html">Log-File</a></li>
            <li><a href="../OnlineEditor/Index.html">Online-Editor</a></li>
            <li><a href="../Sonstiges/Index.html">Sonstige Seiten</a></li>
        </ul>
    </div>
    <div class="container">
        <div class="UnterMenu">
            <p><a href="BotStatus.php">Gesamtes Log</a></p>
            <p><a href="Logbuch.php">Log Splatink</a></p>
            <p><a>Eintrag 3</a></p>
        </div>
        <div class="Inhalt">
                
            <?php
                //Hat hier nichts mit dem Bot zu tun, sondern zum Auslesen anderer Logdateien. Pfad muss entsprechend angegeben, bz>
                echo "Logs der CronJobs: <br/>";

                echo"<h3>Log-File des Autostart-Skriptes</h3>";
                echo"<div class=\"LogEintrag\">";
                $InhaltCron = file_get_contents('/home/pi/AusgabeCron.txt');
                echo str_replace("\n","</br>",$InhaltCron);
                echo"</div>";

                echo"<h3>Log-File Uploader Statink</h3>";
                echo"<div class =\"LogEintrag\">";
                $InhaltStatInk = file_get_contents('/home/pi/AusgabeCronPy.txt');
                echo str_replace("\n","</br>",$InhaltStatInk);
                echo"</div>";

                echo"<h3>Log-File Uploader Statink-Salmon</h3>";
                echo"<div class =\"LogEintrag\">";
                $InhaltStatInkSalmon = file_get_contents('/home/pi/AusgabeCronPySalmon.txt');
                echo str_replace("\n","</br>",$InhaltStatInkSalmon);
                echo"</div>";

                echo"<h3>Log-File Uploader Statink von Splatoon 3</h3>";
                echo"<div class =\"LogEintrag\">";
                $InhaltStatInkS3s = file_get_contents('/home/pi/AusgabeS3s.txt');
                echo str_replace("\n","</br>",$InhaltStatInkS3s);
                echo"</div>";
            ?>

        </div>
    </div>

    
</body>
