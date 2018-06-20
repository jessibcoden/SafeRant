app.service("RantsService", function ($http, $q) {

    var addRant = function (newRant) {
        return $q((resolve, reject) => {
            $http.post(`/api/rants`, newRant).then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in addRant in Service", err);
            });
        });
    }

    const getRantById = (rantId) => {
        return $http.get(`/api/rants/${rantId}`);
    };

    const updateRantDetails = (rant) => {
        return $q((resolve, reject) => {
            $http.put(`/api/rants/${rant.Id}`, rant).then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in updateRantDetails in Service", err);
            });
        });
    }

    const deleteRant = (rantId) => {
        return $http.delete(`/api/rants/${rantId}`);
    };


    return { addRant, deleteRant, getRantById, updateRantDetails };
});