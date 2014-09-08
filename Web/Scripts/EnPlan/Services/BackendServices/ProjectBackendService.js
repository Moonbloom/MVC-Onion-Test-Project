function ProjectBackendService(ajax) {
    return {
        GetAllProjectNames: function() {
            return ajax.call({
                url: ajax.buildUrl("api/Project"),
                type: "GET"
            });
        },

        GetProjectInfo: function(id) {
            return ajax.call({
                url: ajax.buildUrl("api/Project/" + id),
                type: "GET"
            });
        }
    };
}