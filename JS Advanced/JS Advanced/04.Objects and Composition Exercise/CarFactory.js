function Solve(clientOrder) {
    const Car = {};
    Car.model = clientOrder.model;
    
    const powertrain = [
        {power : 90, volume : 1800},
        {power : 120, volume : 2400},
        {power : 200, volume : 3500} 
    ];

    const carriage = [
        {type : 'hatchback', color : clientOrder.color},
        {type : 'coupe', color : clientOrder.color} 
    ];

    
    let addWheels = (size) => Array(4).fill(Math.floor(size) % 2 === 0 ? Math.floor(size) - 1 : Math.floor(size));

    Car.engine = powertrain.find(x => x.power >= clientOrder.power);
    Car.carriage = carriage.find(x => x.type === clientOrder.carriage);
    Car.wheels = addWheels(clientOrder.wheelsize);
    
    return Car;
}

Solve({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 });



