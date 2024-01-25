function solution(input) {
    let result = [];

    input.forEach(pair => {
        let [command, value] = pair.split(' ');
        
        if (command === 'add') {
            result.push(value);
        } else if (command === 'remove') {
            result = result.filter(element => element !== value);
        } else {
            console.log(result.join(','));
        }
    });
};

solution(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solution(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);