window.addEventListener('load', () => {
    let editBtn = document.getElementById('edit');
    let editableArea = document.querySelectorAll('.editableArea');;
    let aboutMe = document.getElementById('aboutMe');
    let birthday = document.getElementById('birthday');


    editBtn.addEventListener('click', () => {
        if (editBtn.classList.contains('closed')) {
            editBtn.classList.add('open');
            editBtn.classList.remove('closed');

            let editIco = document.createElement('i')
            editIco.classList.add('fa')
            editIco.classList.add('fa-edit')

            let editText = document.createElement('span');
            editText.textContent = ' Duzenlemeyi bitir'

            while (editBtn.firstChild) {
                editBtn.removeChild(editBtn.firstChild);
            }

            editBtn.appendChild(editIco)
            editBtn.appendChild(editText)

            console.log(editableArea)
            editableArea.forEach((element) => {
                element.style.display = 'flex';
            })
            aboutMe.disabled = false;
            birthday.disabled = false;
        }
        else {
            editBtn.classList.add('closed');
            editBtn.classList.remove('open');

            let editIco = document.createElement('i')
            editIco.classList.add('fa')
            editIco.classList.add('fa-edit')

            let editText = document.createElement('span');
            editText.textContent = ' Bilgileri Duzenle'

            while (editBtn.firstChild) {
                editBtn.removeChild(editBtn.firstChild);
            }

            editBtn.appendChild(editIco)
            editBtn.appendChild(editText)
            
            editableArea.forEach((element) => {
                element.style.display = 'none';
            })
            aboutMe.disabled = true;
            birthday.disabled = true;
        }
        
    })
    
    
    

})