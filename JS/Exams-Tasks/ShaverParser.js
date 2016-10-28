function solve(args) {
    var n = parseInt(args[0]),
        i,
        model = {};
    for (i = 0; i < n; i++) {
        var currentKeyValuePair = args[i + 1].split(':');
        var key = currentKeyValuePair[0];
        var value = currentKeyValuePair[1];

        if(value == 'true'){
            value = true;
        }
        else if(value == 'false'){
            value = false;
        }
        else if(value.indexOf(',') > -1){
            value = value.split(',');
        }

        model[key] = value;
    }

    var m = parseInt(args[n + 1]);

    var inShaver = false;
    var inSection = false;
    var inLoop = false;
    var render = true;

    var currentSectionName = '';
    var currentSectionContent = [];
    var allSections = {};
    var currentModelKeyName = '';
    var currentLoopKey = '';
    var currentLoopCollection = [];
    var currentLoopContent = [];

    var result = [];
    for (var j = n + 2; j < n + 2 + m; j++) {
        var  currentLine = args[j];

        if(currentLine === undefined){
            currentLine = '';
        }

        if(!render && currentLine.indexOf('}') > -1){
            render = true;
        }

        //check ending of section
        if(inSection && currentLine.indexOf('}') > -1){
            inSection = false;
            allSections[currentSectionName] = currentSectionContent.join('\n');
            currentSectionName = '';
            currentSectionContent = [];
            continue;
        }

        if(inLoop && currentLine.indexOf('}') > -1){
            inLoop = false;
            for (var a = 0; a < currentLoopCollection.length; a++) {
                var content = currentLoopContent.join('').trim()
                    .replace('@' + currentLoopKey + ' ', currentLoopCollection[a] + ' ')
                    .replace('@' + currentLoopKey + '<', currentLoopCollection[a]) + '<';
                result.push(content);
                result.push('\n');
            }

            currentLoopKey = '';
            currentLoopCollection = [];
            currentLoopContent = [];

            continue;
        }

        if(currentLine.indexOf('}') > -1){
            continue;
        }


        if(inSection){
            currentSectionContent.push(currentLine);
            continue;
        }


        for (var k = 0; k < currentLine.length; k++) {
            var currentSymbol = currentLine[k];

            if (currentSymbol === '@') {
                if (currentLine[k + 1] === '@') {
                    result.push('@');
                    k += 1;
                    continue;
                }
                inShaver = true;
                continue;
            }

            //check defining in sections
            if (checkIfInCommand(inShaver, currentLine, 'section ')) {
                //get name of section
                currentSectionName = currentLine.split(' ')[1];
                inSection = true;
                inShaver = false;
                break;
            }

            //check if rendering section
            if(currentLine.indexOf('@renderSection("') > -1){
                inShaver = false;
                var sectionName = currentLine.split('"')[1];
                var sectionContent = allSections[sectionName];
                result.push(sectionContent);
                break;
            }


            //check for if command
            if(checkIfInCommand(inShaver, currentLine, 'if ')){
                var indexOfOpenBracket = currentLine.indexOf('(');
                var indexOfClosedBracket = currentLine.indexOf(')');

                var propertyNameCondition = currentLine.substring(indexOfOpenBracket + 1, indexOfClosedBracket);
                var modelValue = model[propertyNameCondition];

                if(!modelValue){
                    render = false;
                }
                break;
            }

            //check for foreach command
            if(checkIfInCommand(inShaver, currentLine, 'foreach ')){
                var partsOfLoop = currentLine.trim().split(' ');
                currentLoopKey = partsOfLoop[2];
                currentLoopCollection = model[partsOfLoop[4].replace(')', '')];
                inLoop = true;
                inShaver = false;
                break;
            }

            //exit shaver mode
            if(inShaver && (currentSymbol === ' ' || currentSymbol === '<')){
                if(!inLoop && model[currentModelKeyName] && render){
                    result.push(model[currentModelKeyName]);
                }
                else if(inLoop){
                    if(model[currentModelKeyName]){
                        currentLoopContent.push(model[currentModelKeyName]);
                    }
                    else{
                        currentLoopContent.push('@' + currentModelKeyName);
                    }
                }
                currentModelKeyName = '';
                inShaver = false;
            }

            if(inShaver){
                currentModelKeyName +=  currentSymbol;
            }

            //add to result
            if (!inShaver && !inSection && render) {
                if(!inLoop){
                    result.push(currentSymbol);
                }
                else if(inLoop){
                    currentLoopContent.push(currentSymbol);
                }
            }
        }

        if(!inShaver && !inSection && render){
            if(!inLoop){
                result.push('\n');
            }
            else if(inLoop){
                currentLoopContent.push('\n');
            }
        }

    }

    console.log(result.join(''));

    function checkIfInCommand(inShaver, currentLine, commandToCheck){
        return inShaver && currentLine.indexOf('@' + commandToCheck) > -1 && currentLine.indexOf('{') > -1;
    }
}

solve([ '6',
    'title:Telerik Academy',
    'showSubtitle:true',
    'subTitle:Free training',
    'showMarks:false',
    'marks:3,4,5,6',
    'students:Pesho,Gosho,Ivan',
    '42',
    '@section menu {',
    '<ul id="menu">',
    '    <li>Home</li>',
    '    <li>About us</li>',
    '</ul>',
    '}',
    '@section footer {',
    '<footer>',
    '    Copyright Telerik Academy 2014',
    '</footer>',
    '}',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '    <title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '    @renderSection("menu")',
    '',
    '    <h1>@title</h1>',
    '    @if (showSubtitle) {',
    '        <h2>@subTitle</h2>',
    '        <div>@@JustNormalTextWithDoubleKliomba ;)</div>',
    '    }',
    '',
    '    <ul>',
    '        @foreach (var student in students) {',
    '            <li>',
    '                @student ',
    '            </li>',
    '            <li>Multiline @title</li>',
    '        }',
    '    </ul>',
    '    @if (showMarks) {',
    '        <div>',
    '            @marks ',
    '        </div>',
    '    }',
    '',
    '    @renderSection("footer")',
    '</body>',
    '</html>' ]);
