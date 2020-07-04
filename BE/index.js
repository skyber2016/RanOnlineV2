const express = require('express')
const app = express()

app.use(express.static('assets'))
app.get('/', function(req, res) {
    res.sendfile('./assets/index.html');
})

app.listen(3000);
console.log("ok");