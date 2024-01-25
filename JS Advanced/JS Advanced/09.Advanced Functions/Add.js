function solution(base) {
    let num = base;

    return (add) => {
        return num + add;
    }
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));