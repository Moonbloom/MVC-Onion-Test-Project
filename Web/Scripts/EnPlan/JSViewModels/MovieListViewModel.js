function MovieListViewModel() {
    return {
        "movieList": ko.observable({}),
        "searchText": ko.observable(),
        "chosenDropDownItemName": ko.observable("Movies"),
        "dropdownMenuItems": ko.observable([{ Name: "Movies" }, { Name: "Shows" }]),
    }
}