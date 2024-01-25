class Ticket {
    constructor(destination, price, status) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
}   

function solution(array, order) {
    let resultArr = array.map(x => {
        let data = x.split('|')
        return new Ticket(data[0], data[1], data[2]);
    })

    let sortedArr = resultArr.sort((a, b) => {
        return a[order].toString().localeCompare(b[order].toString());
    }) 
    console.log(...sortedArr);
}


solution(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination');

solution(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'status'
)