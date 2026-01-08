function getCookie(key){
    var keyValueArr = document.cookie.split(";")
    for (const element of keyValueArr) {
        var k = element.trim().split("=")[0]
        if(k === key){
            return element.trim().split("=")[1]
        }
    }
}

function setCookie(key, newValue, newExpireDate){
    document.cookie = key+"="+newValue+"; expires="+newExpireDate
}

function deleteCookie(key){
    var keyValueArr = document.cookie.split(";")
    for (const element of keyValueArr) {
        var k = element.trim().split("=")[0]
        if(k === key){
            document.cookie = key+"= ; expires="+oldDate
        }
    }
}

function allCookieList(){
    var keyValueArr = document.cookie.split(";")
    var cookiesArr = []
    for (const element of keyValueArr) {
        var k = element.trim().split("=")[0]
        var v = element.trim().split("=")[1]
        cookiesArr.push({key: k, value: v})
    }
    console.log(cookiesArr);
}

function hasCookie(key){
    var keyValueArr = document.cookie.split(";")
    for (const element of keyValueArr) {
        var k = element.trim().split("=")[0]
        if(k === key){
            return true;
        }
    }
    return false;
}
