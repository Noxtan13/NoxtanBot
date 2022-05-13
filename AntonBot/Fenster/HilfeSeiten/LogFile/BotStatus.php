<!DOCTYPE html>
<html>
<head>
    <title>Startseite NoxtanBot</title>
    <link rel="icon" href="PinguinServer.jpg" />
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
            <p><a>Eintrag 2</a></p>
            <p><a>Eintrag 3</a></p>
        </div>
        <div class="Inhalt">
                
            <?php

    exec("pgrep -u pi mono", $output, $return);
    if($return) {
    echo "NoxtanBot not running!\n";
    } else {
    echo "NoxtanBot OK\n";
    }

    echo "Anzahl des gestarteten Bots: <br/>";
    $Anzahl = file_get_contents('/home/pi/Ausfall.txt');
    echo "$Anzahl <br/>";
    
    echo "Jetzt kommen die Einträge <br/>";
    $InhaltJson = file_get_contents('°LogPfad');
    //$InhaltJson = file_get_contents('/home/pi/Antonbot/KonsolenAusgabe.json');
    //$Eintrag = new Eintraege;
    $Eintrag = json_decode($InhaltJson,true);
    //var_dump($Eintrag);
    
    
    $Ausfalldauer=0;
    foreach($Eintrag as &$value){
        echo"<div class=\"LogEintrag\">";
        echo $value['AusgabeTyp'];
        echo " - ";
        echo $value['AusgabeDatum'];
        echo " - ";
        echo $value['AusgabeZeitpunkt'];
        echo " --- ";
        echo $value['AusgabeText'];
        echo"</div>";
        if(!is_null($value['AusgabeZusatzInfo'])){
            $Ausfalldauer = $Ausfalldauer+ (int)$value['AusgabeZusatzInfo'];
        }
    }
    
    unset($value);

    echo "<br/>Ausgabe ZusatzInfo: $Ausfalldauer<br/>"; 

    $GesamtDauer = $Ausfalldauer+(int)$Anzahl*60;
    echo "Bisher gesamte Ausgefallene Zeit in Sekunden: $GesamtDauer";
    ?>

        </div>
    </div>

    
</body>
