window.addEventListener('load', solve);

function solve() {
    let nextButtonElement = document.getElementById('next-btn');

    nextButtonElement.addEventListener('click', (event) => {
        event.preventDefault();
        let [carModel, carYear, partName, partNumber] = Array.from(document.querySelectorAll('div[class="container-text"] form input')).map(element => element.value)
        let conditionElement = document.querySelector('div[class="container-text"] form select');
        
        if (carModel == "" || carYear == "" || partName == "" || partNumber == "") {
            return;
        }

        carYear = Number(carYear);
        if (carYear < 1980 || carYear > 2023) {
            return;
        }

        //Creating table and adding to Part Info

        let infoListElement = document.querySelector('ul[class="info-list"]');

        let liPartContentElement = document.createElement('li');
        liPartContentElement.setAttribute('class', 'part-content');

        let articleElement = document.createElement('article');
        
        let pCarModel = document.createElement('p')
        pCarModel.textContent = `Car Model: ${carModel}`

        let pCarYear = document.createElement('p')
        pCarYear.textContent = `Car Year: ${carYear}`

        let pPartName = document.createElement('p')
        pPartName.textContent = `Part Name: ${partName}`

        let pPartNumber = document.createElement('p')
        pPartNumber.textContent = `Part Number: ${partNumber}`

        let pCondition = document.createElement('p')
        pCondition.textContent = `Condition: ${conditionElement.value}`

        articleElement.appendChild(pCarModel);
        articleElement.appendChild(pCarYear);
        articleElement.appendChild(pPartName);
        articleElement.appendChild(pPartNumber);
        articleElement.appendChild(pCondition);


        let editBtn = document.createElement("button");
        editBtn.setAttribute('class', 'edit-btn');
        editBtn.textContent = 'Edit';

        let continueBtn = document.createElement("button");
        continueBtn.setAttribute('class', 'continue-btn');
        continueBtn.textContent = 'Continue';

        liPartContentElement.appendChild(articleElement);
        liPartContentElement.appendChild(editBtn);
        liPartContentElement.appendChild(continueBtn);
        infoListElement.appendChild(liPartContentElement);
        
        //Clearing the input fields
        Array.from(document.querySelectorAll('div[class="container-text"] form input')).map(element => element.value = '');
        let conditionElementBeforeEdit = conditionElement.value;
        conditionElement.value = '';
        nextButtonElement.disabled = true;
        
        //Edit button
        editBtn.addEventListener('click', (event) => {
            let beforePartData = [carModel, carYear, partName, partNumber];
            let elementsArray = Array.from(document.querySelectorAll('div[class="container-text"] form input'));

            for (let i = 0; i < beforePartData.length; i++) {
                elementsArray[i].value = beforePartData[i];
            }

            conditionElement.value = conditionElementBeforeEdit;
            liPartContentElement.remove()

            nextButtonElement.disabled = false;
        })

        //Continue Button
        continueBtn.addEventListener('click', (event) => {
            let ulConfirmListElement = document.querySelector('ul[class="confirm-list"]')
            
            let liElement = document.createElement('li');
            liElement.setAttribute('class', 'part-content');

            let articleElementNew = document.createElement('article')
            articleElementNew = articleElement; 

            
            let confirmBtn = document.createElement('button');
            confirmBtn.setAttribute('class', 'confirm-btn');
            confirmBtn.textContent = 'Confirm';
            
            let cancelBtn = document.createElement('button');
            cancelBtn.setAttribute('class', 'cancel-btn');
            cancelBtn.textContent = 'Cancel';
            
            liElement.appendChild(articleElementNew);
            liElement.appendChild(confirmBtn);
            liElement.appendChild(cancelBtn);

            ulConfirmListElement.appendChild(liElement);
            liPartContentElement.remove();

            confirmBtn.addEventListener('click', () => {
                liElement.remove();
                nextButtonElement.disabled = false;

                let orderCompleteText = document.getElementById('complete-text');
                orderCompleteText.textContent = 'Part is Ordered!';

                let completeImage = document.getElementById('complete-img');
                completeImage.style.visibility = 'visible';

            })

            cancelBtn.addEventListener('click', () => {
                liElement.remove();

                nextButtonElement.disabled = false;
            })
        })
    });
};