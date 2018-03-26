function attachEvents() {
    let baseUrl = `https://baas.kinvey.com/appdata/kid_ByQIFVUqf`;
    let username = 'user';
    let password = 'user';
    let auth = 'Basic ' + btoa(username + ":" + password);
    let $catchesContainer = $('#catches');
    let addFields = bindFields('#addForm');

    $('#aside button[class="load"]').on('click', loadData);
    $('#aside button[class="add"]').on('click', function () {
        addCatch(addFields);
    });

    function clearAddFields(fields) {

        for (let key in fields) {
            fields[key].val('');
        }
    }

    function bindFields(selector) {

        return {
            $angler: $(`${selector} .angler`),
            $weight: $(`${selector} .weight`),
            $species: $(`${selector} .species`),
            $location: $(`${selector} .location`),
            $bait: $(`${selector} .bait`),
            $capture: $(`${selector} .captureTime`),
        }
    }

    function renderCatch($parent, data) {
        console.log(data);
        let $catchView = $(`<div class="catch" data-id="${data._id}">
            <label>Angler</label>
            <input type="text" class="angler" value="${data.angler}"/>
            <label>Weight</label>
            <input type="number" class="weight" value="${data.weight}"/>
            <label>Species</label>
            <input type="text" class="species" value="${data.species}"/>
            <label>Location</label>
            <input type="text" class="location" value="${data.location}"/>
            <label>Bait</label>
            <input type="text" class="bait" value="${data.bait}"/>
            <label>Capture Time</label>
            <input type="number" class="captureTime" value="${data.captureTime}"/>
            <button class="update">Update</button>
            <button class="delete">Delete</button>
        </div>`);
        $parent.append($catchView);

        let catchFields = bindFields(`div[data-id="${data._id}"]`);

        $catchView.find('button[class="update"]').on('click', function () {

            updateCatch(data._id, extractData(catchFields));
        });

        $catchView.find('button[class="delete"]').on('click', function () {
            deleteCatch(data._id);
        });

    }

    function extractData(fields) {
        return {
            angler: fields.$angler.val(),
            weight: Number(fields.$weight.val()),
            species: fields.$species.val(),
            location: fields.$location.val(),
            bait: fields.$bait.val(),
            captureTime: Number(fields.$capture.val())
        };
    }

    function loadData() {

        $.ajax(
            {
                method: 'GET',
                url: baseUrl + '/biggestCatches',
                headers: {"Authorization": auth}
            }
        ).then(function (data) {
            $catchesContainer.empty();
            data.forEach((obj) => {
                renderCatch($catchesContainer, obj);
            });

        })
    }

    function addCatch(fields) {
        let data = JSON.stringify(extractData(fields));
        $.ajax({
            method: "POST",
            url: baseUrl + "/biggestCatches",
            headers: {"Authorization": auth},
            data: data
        }).then(function () {
            console.log("Added new catch");
            loadData();
        }).then(function(){
            clearAddFields(fields);
        });
    }

    function updateCatch(id, data) {

        let url = baseUrl + `/biggestCatches/${id}`;
        $.ajax({
            url: url,
            method: "PUT",
            headers: {"Authorization": auth},
            data: JSON.stringify(data),
        }).then(function () {
            console.log(`Updated catch with id="${id}"`);
            loadData();
        });
    }

    function deleteCatch(catchId) {

        $.ajax({
            url: baseUrl + `/biggestCatches/${catchId}`,
            method: "DELETE",
            headers: {"Authorization": auth},

        }).then(function () {
            console.log(`deleted catch with id ${catchId}`);
            loadData();
        })
    }
}