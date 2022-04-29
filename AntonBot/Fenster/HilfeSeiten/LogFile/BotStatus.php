<!DOCTYPE html>
<html>
<head>
    <title>Twitch-Anleitung</title>
    <style>
        .ContainerText {
            border: 5px outset red;
            background-color: lightblue;
            text-align: center;
        }
    </style>
</head><body>

    <?php

    echo "Das ist der Codeanfang vom PHP-Teil<br />";



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
    $InhaltJson = file_get_contents('/home/pi/Antonbot/KonsolenAusgabe.json');
    //$Eintrag = new Eintraege;
    $Eintrag = json_decode($InhaltJson,true);
    //var_dump($Eintrag);
    
    echo "<br/><br/>Ausgabe der Einträge:<br/>";
    $Ausfalldauer=0;
    foreach($Eintrag as &$value){
        echo $value['AusgabeTyp'];
        echo " - ";
        echo $value['AusgabeZeitpunkt'];
        echo " --- ";
        echo $value['AusgabeText'];
        echo "<br/>";
        if(!is_null($value['AusgabeZusatzInfo'])){
            $Ausfalldauer = $Ausfalldauer+ (int)$value['AusgabeZusatzInfo'];
        }
    }
    unset($value);

    echo "<br/>Ausgabe ZusatzInfo: $Ausfalldauer<br/>"; 

    $GesamtDauer = $Ausfalldauer+(int)$Anzahl*60;
    echo "Bisher gesamte Ausgefallene Zeit in Sekunden: $GesamtDauer";
    ?>
</body>
