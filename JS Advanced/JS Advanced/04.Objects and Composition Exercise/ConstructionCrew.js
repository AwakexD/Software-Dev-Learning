function Solve(workerObj) {
    const Hydratate = () => {
        let requiredAmount = 0.1 * workerObj.weight * workerObj.experience;
        workerObj.levelOfHydrated += requiredAmount;
    } 
    
    if (workerObj.dizziness) {
        Hydratate();
        workerObj.dizziness = false;
    }

    return workerObj;
}

Solve({ weight: 80,
 experience: 1,
 levelOfHydrated: 0,
 dizziness: true });