

var setTimeoutValue = 1000;

function funDeleteUser(id) {
    if (confirm("Are you sure you want to delete this user?")) {
        window.location.href = '/Users/Delete/' + id;
    }
    else { return false; }
}




var color = ['#d91d741f', '#ccc', 'blue'];

setInterval(function () {
    changeBackgroundColor();
}, setTimeoutValue);


function changeBackgroundColor() {
    const randomInteger = getRandomInt(0, 2);
    document.getElementById("div1").style.backgroundColor = color[randomInteger];
}


function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1)) + min;
}