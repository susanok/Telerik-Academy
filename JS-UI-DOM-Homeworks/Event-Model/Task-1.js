/* TASK
 Create a function that takes an id or DOM element and:

 If an id is provided, select the element
 Finds all elements with class button or content within the provided element
 Change the content of all .button elements with "hide"
 When a .button is clicked:
 Find the topmost .content element, that is before another .button and:
 If the .content is visible:
 Hide the .content
 Change the content of the .button to "show"
 If the .content is hidden:
 Show the .content
 Change the content of the .button to "hide"
 If there isn't a .content element after the clicked .button and before other .button, do nothing
 Throws if:
 The provided DOM element is non-existant
 The id is neither a string nor a DOM element*/

function solve() {
    function checkIsUndefined(input){
        if(input === undefined){
            throw new Error();
        }
    }

    function validateElement(input) {

        if (typeof  input[i] !== 'string' && !(input instanceof HTMLElement)) {
            throw new Error();
        }
    }

    return function solution(selector){
        checkIsUndefined(selector);
        validateElement(selector);

        var i,
            currentChild,
            content,
            element = document.getElementById(selector) || selector,
            children = element.childNodes,
            len = children.length;

        for(i = 0; i < len; i += 1){
            currentChild = children[i];

            if(currentChild.className === 'button'){
                currentChild.innerHTML = 'hide';
            }
        }

        element.addEventListener('click', function(ev){
            var clickedButton,
                nextElement;

            if(ev.target.className !== 'button'){
                return;
            }

            clickedButton = ev.target;
            nextElement = clickedButton.nextElementSibling;

            if(nextElement.className === 'content'){
                content = nextElement;

                while(nextElement){
                    if(nextElement.className === 'button'){
                        if(content.style.display === 'none'){
                            content.style.display = '';
                            clickedButton.innerHTML = 'hide';
                        } else {
                            content.style.display = 'none';
                            clickedButton.innerHTML = 'show';
                        }

                        break;
                    }
                }

                nextElement = nextElement.nextElementSibling;
            }
        }, false);

    }
}

