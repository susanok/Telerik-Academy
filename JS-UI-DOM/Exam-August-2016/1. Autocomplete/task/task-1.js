/* globals document, window, console */

function solve() {
    return function(selector, initialSuggestions) {
        var itemsToShow = [];
        var elementAuto = document.querySelector(selector);
        var element = elementAuto.lastElementChild;
        if(initialSuggestions){
            for(var i = 0, len = initialSuggestions.length; i < len; i += 1){
                var li = createNewLi(initialSuggestions[i]);
                element.appendChild(li);
                itemsToShow.push(initialSuggestions[i]);
            }
        }

        var input = document.getElementsByTagName('input')[0];

        var itemsList = document.getElementsByClassName('suggestions-list')[0];

        itemsList.addEventListener('click', function(ev){
            if (ev.target.className.indexOf('suggestion-link') >= 0) {
                input.value = ev.target.textContent;
            }
        });
        debugger;
        var v = input.value;

        input.addEventListener('input', function(){
            var items = document.getElementsByClassName('suggestion');

            for(var i = 0; i < items.length; i += 1){
                if(items[i].firstChild.innerHTML.toLowerCase().indexOf(input.value.toLowerCase()) >= 0 && input.value.toLowerCase() !== ""){
                    items[i].style.display = '';
                } else {
                    items[i].style.display = 'none';
                }
            }
        });
        var btnAdd = document.getElementsByClassName('btn-add')[0];

        btnAdd.addEventListener('click', function(){

            var inputValue = input.value;
            var hasNotSuggestion = true;
            for(var a = 0; a < itemsToShow.length; a += 1){
                if(inputValue.toLowerCase() === itemsToShow[a].toLowerCase()){
                    hasNotSuggestion = false;
                }
            }

            if(hasNotSuggestion){
                itemsToShow.push(inputValue);
                var newLi = createNewLi(inputValue);
                element.appendChild(newLi);
            }

            input.value = '';
        });

        function createNewLi(text){
            var li = document.createElement('li');
            li.className = "suggestion";
            li.style.display = "none";

            var anchor = document.createElement('a');
            anchor.href = '#';
            anchor.className = 'suggestion-link';
            anchor.innerHTML = text;

            li.appendChild(anchor);

            return li;
        }
    };
}

module.exports = solve;

/*<li class="suggestion">
 <a href="#" class="suggestion-link">Apple</a>
 </li>
    */