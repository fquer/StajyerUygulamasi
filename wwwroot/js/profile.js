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
    
    let experienceTable = document.getElementById("experience");
    if (experiences.length != 0) {

        experiences.forEach( (dbExperience) => {
            let experienceRow = document.createElement("tr");

            let experienceCompanyData = document.createElement("td");
            let experiencePositionData = document.createElement("td");
            let experienceStartTimeData = document.createElement("td");
            let experienceFinishTimeData = document.createElement("td");

            experienceCompanyData.innerHTML = dbExperience.companyName;
            experiencePositionData.innerHTML = dbExperience.position;
            experienceStartTimeData.innerHTML = dbExperience.startTime.split('T')[0];
            experienceFinishTimeData.innerHTML = dbExperience.finishTime.split('T')[0];

            experienceRow.appendChild(experienceCompanyData);
            experienceRow.appendChild(experiencePositionData);
            experienceRow.appendChild(experienceStartTimeData);
            experienceRow.appendChild(experienceFinishTimeData);

            experienceTable.appendChild(experienceRow);
        })  
    }
    else {
        experienceTable.style.display = 'none';
    }
    console.log(educations)
    let educationTable = document.getElementById("education");
    if (educationTable.length != 0) {

        educations.forEach((dbEducation) => {
            let educationRow = document.createElement("tr");

            let educationName = document.createElement("td");
            let educationStartTimeData = document.createElement("td");
            let educationFinishTimeData = document.createElement("td");

            educationName.innerHTML = dbEducation.educationName;
            educationStartTimeData.innerHTML = dbEducation.startTime.split('T')[0];
            educationFinishTimeData.innerHTML = dbEducation.finishTime.split('T')[0];

            educationRow.appendChild(educationName);
            educationRow.appendChild(educationStartTimeData);
            educationRow.appendChild(educationFinishTimeData);

            educationTable.appendChild(educationRow);
        })
    }
    else {
        educationTable.style.display = 'none';
    }
})