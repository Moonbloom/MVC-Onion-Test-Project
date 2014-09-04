function MovieListViewModel() {
    var self = this;
    self.movieList = ko.observable();
    self.searchText = ko.observable();

    self.searchText.subscribe(function (newValue) {
        $.getJSON("http://www.omdbapi.com/", { s: newValue }, function (data) {
            console.log(data);
            self.movieList(data.Search);
        });
    });

    self.clickClear = function() {
        alert("clear!");
    };
}