/*  TASK
Create a function that takes an id or DOM element and an array of contents

 If an id is provided, select the element
 Add divs to the element
 Each div's content must be one of the items from the contents array
 The function must remove all previous content from the DOM element provided
 Throws if:
 The provided first parameter is neither string or existing DOM element
 The provided id does not select anything (there is no element that has such an id)
 Any of the function params is missing
 Any of the function params is not as described
 Any of the contents is neither string nor number
 In that case, the content of the element must not be changed*/

function solve() {
    function checkIsUndefined(input){
        if(input === undefined){
            throw new Error();
        }
    }

    function validateArray(input){
        if(Array.isArray(input)){
            var i,
                len;

            for(i = 0, len = input.length; i < len; i += 1){
                checkIsUndefined(input[i]);

                if(typeof  input[i] !== 'string'){
                    if(typeof  input[i] !== 'number'){
                        throw new Error();
                    }
                }
            }
        }
        else {
            throw new Error();
        }
    }

    return function changeContent(element, contents){
        checkIsUndefined(element);
        validateArray(contents);

        var documentFragment = document.createDocumentFragment(),
            divToClone = document.createElement('div'),
            mainElement = document.getElementById(element) || element,
            i,
            len;

        for(i = 0, len = contents.length; i < len; i += 1){
            var div = divToClone.cloneNode(true);
            div.innerHTML = contents[i];
            documentFragment.appendChild(div);
        }

        checkIsUndefined(mainElement);
        mainElement.innerHTML = '';
        mainElement.appendChild(documentFragment);
    }
}
