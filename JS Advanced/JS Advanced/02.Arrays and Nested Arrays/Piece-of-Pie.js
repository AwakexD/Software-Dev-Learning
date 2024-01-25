function Solve(pieFlavors, target1, target2) {
    const startIndex = pieFlavors.indexOf(target1);
    const endIndex = pieFlavors.indexOf(target2) + 1;

    let newFlavours = pieFlavors.slice(startIndex, endIndex)
    console.log(newFlavours);
};

Solve(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie')

Solve(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie')