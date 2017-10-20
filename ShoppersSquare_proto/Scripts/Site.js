
function AddProductToCart(id) {
    var goToLogin = function () {
        location.href = "/login?returnurl=" + location.pathname;
    };
    console.log(id);
if (id === undefined || id === null)
        return;

    var xhr = new XMLHttpRequest();
    xhr.responseType = 'json';

    xhr.onload = function () {
        if (xhr.response.status === "Unauthorized")
            goToLogin();
        else if (xhr.response.status === "Ok")
            window.alert(xhr.response.msg);
        else
            window.alert(xhr.response.msg);
    };

    xhr.onerror = function () {
        console.log('error' + xhr.response);
    };

    xhr.onreadystatechange = function () {
        console.log(xhr.status);
    };

    xhr.open('POST', '/Products/AddToCart', true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.send("id=" + id);
}

//Get search results 
(function () {
    //redirect to search on submit
    var searchInput = document.getElementById('searchInput');
    var productsSearchForm = document.getElementById('productsSearchForm');
    productsSearchForm.onsubmit = function (e) {
        e.preventDefault();
        if (searchInput.value.length > 0) {
            location.pathname = 'search/' + searchInput.value;
        }
    };

    //Get Search Results on input
    var searchResults = document.getElementById('searchResults');
    searchInput.addEventListener('input', function (e) {
        var xhr = new XMLHttpRequest();
        xhr.responseType = 'json';

        xhr.onload = function () {
            searchResults.innerHTML = "";
            var results = xhr.response;
            if (results !== null) {
                results.forEach(function (result, i) {
                    searchResults.innerHTML += '<li class="search-item"><a href="/product/' + result.id + '/' + result.name + '"/>' + result.name + '</a></li>';
                });
            }
        };

        xhr.open("GET", "/Products/SearchProducts/" + searchInput.value, true);
        xhr.send();
    });
})();