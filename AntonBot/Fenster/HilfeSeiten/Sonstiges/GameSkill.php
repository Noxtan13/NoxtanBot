﻿<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="refresh" content="5">
    <meta charset="UTF-8">
    <style>
        body {
            justify-content: center;
            align-items: center;
            background: rgba(1,1,1,0.0);
            display: block;
            height: 100vh;
            padding: 0;
            margin: 0;
         }

        .progress {
            background: rgba(20,114,37,0.75);
            justify-content: flex-start;
            border-radius: 100px;
            align-items: center;
            position: relative;
            padding: 0 5px;
            display: flex;
            height: 40px;
            width: 100%;
        }

        .progress-value {
            animation: load 3s normal forwards;
            box-shadow: 0 10px 40px -10px #fff;
            border-radius: 100px;
            background: rgba(90,188,54,1);
            height: 30px;
            width: 0;
        }
        .ExpText{
	        text-align:center;
	        width:inherit;
	        z-index: 1;
	        position: absolute;
	        font-size: 20px;
	        padding-top:10px;
	        font-family: Verdana, sans-serif;
	    }
        .text {
            color: #ffffff;
			word-break: keep-all;
			-webkit-text-stroke-width: 1px;
            -webkit-text-stroke-color: black;
            font-size: 23px;
			font-weight: bold;
            align-items: center;
            padding: 5px;
            z-index: 1;
            display: flex;
            height: auto;
            width: 750px;
	        font-family: Verdana, sans-serif;      
	    }
        .Box{
            height:50px;
            width: 750px;
            align-items: center
        }

        @keyframes Zahl {
            0%{top:10px;
               color: rgba(0,0,0,1);
            }
            100% {
                top: -50px;
                color: rgba(0,0,0,0);
            }
        }
        .EXP {
            animation: Zahl 3s normal;
            position: absolute;
            left: 250px;
            font-family: Verdana, sans-serif;
            color: rgba(0,0,0,0);
            font-size: 23px;
            font-weight: bold;
        }

        @keyframes load {
            <?php 
                $InhaltJson = file_get_contents('/home/pi/Antonbot/SkillAusgabe.json');
                //$Eintrag = new Eintraege;
                $Eintrag = json_decode($InhaltJson,true);

                //Wenn die Datei noch nicht gelesen wurde, dann soll die Animation abgespielt werden
                if ($Eintrag["read"]==0){
                    $AltProzent=$Eintrag["AltProzent"];
                }
                else{
                    $AltProzent=$Eintrag["NeuProzent"];
                }
                $NeuProzent=$Eintrag["NeuProzent"];
                //var_dump($Eintrag);

                $differenz=$Eintrag["NeuLevel"]-$Eintrag["AltLevel"];
                if($differenz>0){
                    $Schritt=100/($differenz+1);
                }


            
                echo "0% { width: $AltProzent%; }";
                //Wenn die Datei noch nicht gelesen wurde, dann soll die Animation (auch über mehrere Level) abgespielt werden
                if ($Eintrag["read"]==0){
                    for($i=1;$i<=$differenz;$i++){
                        $ZSchritt=$Schritt*$i;
                        echo"$ZSchritt% { width: 100%;}";
                        $Neu = $ZSchritt+1;
                        echo "$Neu% { width: 0%;}";
                    }
                }

                echo "100% { width: $NeuProzent%; }";
            ?>
        }
    </style>
</head>
<body>


<div class="text"> 
    <?php 
        $InhaltJson = file_get_contents('/home/pi/Antonbot/SkillAusgabe.json');
        $Eintrag = json_decode($InhaltJson,true);

        $QuestInhalt=$Eintrag["CurrentMainQuest"];

        echo "$QuestInhalt";
    ?>
</div>
<div class="Box">
    <div class="ExpText">
    <?php 
        $InhaltJson = file_get_contents('/home/pi/Antonbot/SkillAusgabe.json');
        $Eintrag = json_decode($InhaltJson,true);

        $EXP=$Eintrag["NeuEXP"];
        $MaxEXP=$Eintrag["NeuMaxEXP"];

        echo "$EXP / $MaxEXP";


    ?>    
    </div>
    <div class="progress">
        <div class="EXP">
            <?php 
                $InhaltJson = file_get_contents('/home/pi/Antonbot/SkillAusgabe.json');
                $Eintrag = json_decode($InhaltJson,true);


                if ($Eintrag["read"]==0){
                    $AddedEXP=$Eintrag["AddedEXP"];
                }
                else{
                    $AddedEXP=0;
                }

                if ($AddedEXP!=0){
                    echo "+$AddedEXP";
                }
                //Da dies der letzte PHP-Abschnitt ist, erfolgt hier die Hinterlegung, ob die Datei schon gelesen worden ist

                $Eintrag["read"]=1;
                $InhaltJsonA =json_encode($Eintrag);
                unlink('/home/pi/Antonbot/SkillAusgabe.json');
                file_put_contents('/home/pi/Antonbot/SkillAusgabe.json',$InhaltJsonA);
            ?> 
        </div>
        <div class="progress-value"></div>
    </div>
</div>


</body>
</html>
