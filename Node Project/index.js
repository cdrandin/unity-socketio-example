var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(1234);

app.get('/', function(req, res){
    res.sendFile(__dirname + '/index.html');
});

io.on('connection', function (socket) {
    console.log("Connected...");

    socket.on('beep', function(){
        console.log('boop');
        socket.emit('boop');
    });

    socket.on('chat message', function(msg){
        io.emit('chat message', msg);
    });
});

//http.listen(1234, function(){
//    console.log('listening on *:3000');
//});
console.log('listening on port 1234');