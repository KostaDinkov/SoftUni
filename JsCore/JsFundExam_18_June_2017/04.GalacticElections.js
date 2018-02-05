function election(data_arr) {

    let results = {
        totalVotes: 0,
        candidates: new Map(),
        allSystems: new Map(),
        winnerBySystem: new Map(),

        _addSystem: function (map, l1, l2, val) {
            if (!map.has(l1)) {
                map.set(l1, new Map());
                map.get(l1).set(l2, val);
            }
            else {
                if (!map.get(l1).has(l2)) {
                    map.get(l1).set(l2, val)
                }
                else {
                    map.get(l1).set(l2, map.get(l1).get(l2) + val)
                }
            }
        },

        addResult: function (system, candidate, votes) {
            this._addSystem(this.allSystems, system, candidate, votes);
            this._addSystem(this.candidates, candidate, system, votes);
            this.totalVotes += votes;

        },
        getWinners: function () {
            let winners = new Map();

            for (let [name, result] of this.allSystems) {
                let total_votes = Array.from(result.values()).reduce((sum, cur) => sum + cur);
                let max_vote = Array.from(result.values()).reduce((max, cur) => Math.max(max, cur));
                let winner = Array.from(result.keys()).find(x => result.get(x) == max_vote);

                if(!winners.has(winner)){
                    winners.set(winner,total_votes);
                }
                else{
                    winners.set(winner,winners.get(winner) + total_votes);
                }
                if(!this.winnerBySystem.has(winner)){
                    this.winnerBySystem.set(winner,new Map());
                }
                this.winnerBySystem.get(winner).set(name,total_votes)

            }
            let winnersSorted = new Map();
            let sortedByVotes = Array.from(winners.keys()).sort((a,b)=>winners.get(b) - winners.get(a));

            for (let name of sortedByVotes) {
                winnersSorted.set(name, winners.get(name));
            }
            return winnersSorted;
        },
        getCandidateSystems:function(candidateName){
            let sorted = new Map();
            let sortedByVotes = Array.from(this.winnerBySystem.get(candidateName).keys())
                .sort((a,b)=>this.winnerBySystem.get(candidateName).get(b)-this.winnerBySystem.get(candidateName).get(a));
            for (let name of sortedByVotes) {
                sorted.set(name,this.winnerBySystem.get(candidateName).get(name))
            }
            return sorted;
        }


    };

    for (let obj of data_arr) {
        results.addResult(obj.system, obj.candidate, obj.votes);
    }


    let winners = (results.getWinners()).entries();
    let first = winners.next().value;
    let second = winners.next().value;

    if(!(first[1]>(results.totalVotes / 2))){
        let firstPerc = Math.floor(first[1]/results.totalVotes*100);
        let secondPerc = Math.floor(second[1]/results.totalVotes*100);
        console.log(`Runoff between ${first[0]} with ${firstPerc}% and ${second[0]} with ${secondPerc}%`)
    }
    else{
        console.log(`${first[0]} wins with ${first[1]} votes`);
        if(second){
            console.log(`Runner up: ${second[0]}`);
            let runnerUpStats = results.getCandidateSystems(second[0]);
            runnerUpStats.forEach((v,k) => console.log(`${k}: ${v}`))
        }
        else{
            console.log(`${first[0]} wins unopposed!`)
        }

    }
    let a =[...results.candidates];
    console.log(a);


    // console.log(results.candidates);
    // console.log(results.allSystems);
    // console.log(results.getWinners());


}
election([ { system: 'Theta', candidate: 'Flying Shrimp', votes: 10 },
    { system: 'Sigma', candidate: 'Space Cow', votes: 200 },
    { system: 'Sigma', candidate: 'Flying Shrimp', votes: 120 },
    { system: 'Tau', candidate: 'Space Cow', votes: 15 },
    { system: 'Sigma', candidate: 'Space Cow', votes: 60 },
    { system: 'Tau', candidate: 'Flying Shrimp', votes: 150 } ]);