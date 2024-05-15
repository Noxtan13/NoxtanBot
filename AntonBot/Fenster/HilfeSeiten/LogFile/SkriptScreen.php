<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="refresh" content="1">
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
     
            <?php
                //Hat hier nichts mit dem Bot zu tun, sondern zum Auslesen anderer Logdateien. Pfad muss entsprechend angegeben, bz>
                echo"<h3>Letzter Screen des AutoTableTurf</h3>";
                echo"<div class =\"LogEintrag\">";				
                echo"<img src='/WebSite/LogFile/test.jpg' alt='Bild des AutoTableTurf' width='889' height='500' />";
                echo"</div>";
            ?>

</body>
