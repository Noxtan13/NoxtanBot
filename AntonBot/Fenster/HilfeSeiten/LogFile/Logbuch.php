<!DOCTYPE html>
<html>
<head>
    <title>Anzeige Logbuch</title>
    <link rel="icon" href="../PinguinServer.jpg" />
    <link rel="icon" href="../PinguinServer.jpg" />
    <link rel="stylesheet" href="../Style.css" />
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
    //Hat hier nichts mit dem Bot zu tun, sondern zum Auslesen anderer Logdateien. Pfad muss entsprechend angegeben, bzw. bearbeitet werden
  
    echo "Jetzt kommen die Einträge <br/>";
    //$InhaltJson = file_get_contents('°LogPfad');
    $InhaltJson = file_get_contents('/home/pi/CronjobAusgabe.txt');
    //$Eintrag = new Eintraege;
    $Eintrag = json_decode($InhaltJson,true);
    //var_dump($Eintrag);
    
    
    $Ausfalldauer=0;

    echo"<div class=\"LogEintrag\">";
    echo $InhaltJson
    echo"</div>";

    ?>

        </div>
    </div>

    
</body>
