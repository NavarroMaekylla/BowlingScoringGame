<html>
<head>
    <meta http-equiv="Page-Enter" content="revealTrans(Duration=0.5,Transition=12)">
    <meta http-equiv="Page-Exit" content="revealTrans(Duration=0.5,Transition=12)">
    <title>Bowling Scoring Game</title>
    <div class="jumbotron">
        <script language=javascript>
            shot = new Array(21);
            score = new Array(11);
            function runScript() {
                store();
                valid = verify();
                if (valid) { calculate(); print(); }
            }

            function store() {
                shot[0] = document.score.shot1a.value;
                shot[1] = document.score.shot1b.value;
                shot[2] = document.score.shot2a.value;
                shot[3] = document.score.shot2b.value;
                shot[4] = document.score.shot3a.value;
                shot[5] = document.score.shot3b.value;
                shot[6] = document.score.shot4a.value;
                shot[7] = document.score.shot4b.value;
                shot[8] = document.score.shot5a.value;
                shot[9] = document.score.shot5b.value;
                shot[10] = document.score.shot6a.value;
                shot[11] = document.score.shot6b.value;
                shot[12] = document.score.shot7a.value;
                shot[13] = document.score.shot7b.value;
                shot[14] = document.score.shot8a.value;
                shot[15] = document.score.shot8b.value;
                shot[16] = document.score.shot9a.value;
                shot[17] = document.score.shot9b.value;
                shot[18] = document.score.shot10a.value;
                shot[19] = document.score.shot10b.value;
                shot[20] = document.score.shot10c.value;
            }
            function verify() {
                for (i = 0; i <= 17; i += 2) {
                    switch (shot[i]) {
                        case 'x': case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9': break;
                        default: alert("Invalid"); return false;
                    }

                    switch (shot[i + 1]) {
                        case '/': if (shot[i] < '0' || shot[i] > '9') { alert("Invalid"); return false; }
                        case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9': if (parseInt(shot[i]) + parseInt(shot[i + 1]) > 9) { alert("Invalid"); return false; } break;
                        default: if (shot[i] != 'x') { alert("Invalid"); return false; }
                    }
                }

                //for tenth frame
                switch (shot[18]) {
                    case 'x': case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9': break;
                    default: alert("Invalid"); return false;
                }

                switch (shot[19]) {
                    case 'x': if (shot[18] != 'x') { alert("Invalid"); return false; } break;
                    case '/': if (shot[18] < '0' || shot[18] > '9') { alert("Invalid"); return false; } break;
                    case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9':
                        if (shot[18] != 'x') { if (parseInt(shot[18]) + parseInt(shot[19]) > 9) { alert("Invalid"); return false; } } break;
                    default: alert("Invalid"); return false;
                }

                if (shot[18] != 'x' && shot[19] != '/') return true;

                switch (shot[20]) {
                    case 'x': if (shot[19] != 'x' && shot[19] != '/') { alert("Invalid"); return false; } break;
                    case '/': if (shot[19] < '0' || shot[19] > '9') { alert("Invalid"); return false; } break;
                    case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9':
                        if (shot[19] != 'x' && shot[19] != '/') { if (parseInt(shot[18]) + parseInt(shot[19]) > 9) { alert("Invalid"); return false; } } break;
                    default: alert("Invalid"); return false;
                }

                return true;
            }

            function calculate() {
                frame = 0;
                lastFrame = 0;
                for (i = 0; i < 8; i++) {
                    if (shot[2 * i] == 'x') {
                        if ((shot[2 * i + 2] == 'x') && (shot[2 * i + 4] == 'x')) 
                            score[i] = lastFrame + 30;
                        else if (shot[2 * i + 2] == 'x') 
                            score[i] = lastFrame + 20 + parseInt(shot[2 * i + 4]);
                        else if (shot[2 * i + 3] == '/') 
                            score[i] = lastFrame + 20;
                        else 
                            score[i] = lastFrame + 10 + parseInt(shot[2 * i + 2]) + parseInt(shot[2 * i + 3]);
                    }

                    else if (shot[2 * i + 1] == '/') { 
                        if (shot[2 * i + 2] == 'x') 
                            score[i] = lastFrame + 20;
                        else 
                            score[i] = lastFrame + 10 + parseInt(shot[2 * i + 2]);
                    }

                    else 
                        score[i] = lastFrame + parseInt(shot[2 * i]) + parseInt(shot[2 * i + 1]);
                    lastFrame = score[i];
                }
                
                if (shot[16] == 'x') {
                    if ((shot[18] == 'x') && (shot[19] == 'x'))
                        score[8] = lastFrame + 30;
                    else if (shot[18] == 'x')
                        score[8] = lastFrame + 20 + parseInt(shot[19]);
                    else if (shot[19] == '/')
                        score[8] = lastFrame + 20;
                    else//will followed by an open in the tenth
                        score[8] = lastFrame + 10 + parseInt(shot[18]) + parseInt(shot[19]);
                }

                else if (shot[17] == '/') {
                    if (shot[18] == 'x')
                        score[8] = lastFrame + 20;
                    else
                        score[8] = lastFrame + 10 + parseInt(shot[18]);
                }

                else 
                    score[8] = lastFrame + parseInt(shot[16]) + parseInt(shot[17]);
                lastFrame = score[8];
                if (shot[18] == 'x') { 
                    if ((shot[19] == 'x') && (shot[20] == 'x'))
                        score[9] = lastFrame + 30;
                    else if (shot[19] == 'x')
                        score[9] = lastFrame + 20 + parseInt(shot[20]);
                    else if (shot[20] == '/')
                        score[9] = lastFrame + 20;
                    else
                        score[9] = lastFrame + 10 + parseInt(shot[19]) + parseInt(shot[20]);
                }

                else if (shot[19] == '/') { 
                    if (shot[20] == 'x') 
                        score[9] = lastFrame + 20;
                    else
                        score[9] = lastFrame + 10 + parseInt(shot[20]);
                }

                else 
                    score[9] = lastFrame + parseInt(shot[18]) + parseInt(shot[19]);
            }

            function print() {
                outputWindow = window.open('', '', 'status=0,height=250,width=500');
                output = "<title>Your Bowling Score</title>"
                output += "<h1>Your Bowling Score</h1><table border=2 width=90%>";
                output += "<tr><td>Frame:</td><td>1</td><td>2</td><td>3</td><td>4</td><td>5</td><td>6</td><td>7</td><td>8</td><td>9</td><td>10</td></tr>";
                output += "<tr><td>Score:</td><td>" + score[0] + "</td>";
                output += "<td>" + score[1] + "</td>";
                output += "<td>" + score[2] + "</td>";
                output += "<td>" + score[3] + "</td>";
                output += "<td>" + score[4] + "</td>";
                output += "<td>" + score[5] + "</td>";
                output += "<td>" + score[6] + "</td>";
                output += "<td>" + score[7] + "</td>";
                output += "<td>" + score[8] + "</td>";
                output += "<td>" + score[9] + "</td>";
                output += "</tr></table>";

                if (score[9] == 300) output += "<br><h3>Congratulations, You have Bowled a 300!!!</h3>";
                output += "<center><a onclick='outputWindow = window.close()' href=''>Close</a></center>"
                outputWindow.document.write(output);
            }
        </script>
</head>

<body bgcolor="#82ffff">
    <center><h1>Bowling Scoring Game</h1></center> <br />
    <form name="score">
        &nbsp;<center>
            <table border="1" cellspacing="1" width="100%" id="AutoNumber1" height="45">
                <tr>
                    <td width="7%" height="19" bgcolor="#003399"><font color="#FFFFFF"><b>Frame</b></font></td>
                    <td width="7%" height="19" bgcolor="#99CCFF" align="center"><b>1</b></td>
                    <td width="7%" height="19" bgcolor="#99CCFF" align="center"><b>2</b></td>
                    <td width="7%" height="19" bgcolor="#99CCFF" align="center"><b>3</b></td>
                    <td width="7%" height="19" bgcolor="#99CCFF" align="center"><b>4</b></td>
                    <td width="7%" height="19" bgcolor="#99CCFF" align="center"><b>5</b></td>
                    <td width="7%" height="19" bgcolor="#99CCFF" align="center"><b>6</b></td>
                    <td width="7%" height="19" bgcolor="#99CCFF" align="center"><b>7</b></td>
                    <td width="7%" height="19" bgcolor="#99CCFF" align="center"><b>8</b></td>
                    <td width="7%" height="19" bgcolor="#99CCFF" align="center"><b>9</b></td>
                    <td width="7%" height="19" bgcolor="#99CCFF" align="center"><b>10</b></td>
                </tr>
                <tr>
                    <td width="7%" height="16" bgcolor="#003399"><font color="#FFFFFF"><center><b>Score</b></center></font></td>
                    <td width="7%" height="16" bgcolor="#99CCFF" align="center"><input type=text maxlength=1 size=1 name="shot1a"> <input type=text maxlength=1 size=1 name="shot1b"></td>
                    <td width="7%" height="16" bgcolor="#99CCFF" align="center"><input type=text maxlength=1 size=1 name="shot2a"> <input type=text maxlength=1 size=1 name="shot2b"></td>
                    <td width="7%" height="16" bgcolor="#99CCFF" align="center"><input type=text maxlength=1 size=1 name="shot3a"> <input type=text maxlength=1 size=1 name="shot3b"></td>
                    <td width="7%" height="16" bgcolor="#99CCFF" align="center"><input type=text maxlength=1 size=1 name="shot4a"> <input type=text maxlength=1 size=1 name="shot4b"></td>
                    <td width="7%" height="16" bgcolor="#99CCFF" align="center"><input type=text maxlength=1 size=1 name="shot5a"> <input type=text maxlength=1 size=1 name="shot5b"></td>
                    <td width="7%" height="16" bgcolor="#99CCFF" align="center"><input type=text maxlength=1 size=1 name="shot6a"> <input type=text maxlength=1 size=1 name="shot6b"></td>
                    <td width="7%" height="16" bgcolor="#99CCFF" align="center"><input type=text maxlength=1 size=1 name="shot7a"> <input type=text maxlength=1 size=1 name="shot7b"></td>
                    <td width="7%" height="16" bgcolor="#99CCFF" align="center"><input type=text maxlength=1 size=1 name="shot8a"> <input type=text maxlength=1 size=1 name="shot8b"></td>
                    <td width="7%" height="16" bgcolor="#99CCFF" align="center"><input type=text maxlength=1 size=1 name="shot9a"> <input type=text maxlength=1 size=1 name="shot9b"></td>
                    <td width="7%" height="16" bgcolor="#99CCFF" align="center"><input type=text maxlength=1 size=1 name="shot10a"> <input type=text maxlength=1 size=1 name="shot10b"> <input type=text maxlength=1 size=1 name="shot10c"></td>
                </tr>
            </table>
            <p>
                <input type=button value="Calculate Score" onclick="runScript();">
                <input type=reset value="Reset">
            </p>
        </center>
    </form>
    <h3>
        <i>
            Score: <b>0-9</b> <font color="#C0C0C0">or</font> <b>x </b>
            <font color="#C0C0C0">or</font><b> /</b>
        </i>
    </h3>
    <hr>
    </div>

</body>
</html>
