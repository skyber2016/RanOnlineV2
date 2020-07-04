(function (lib, img, cjs, ss) {

var p; // shortcut to reference prototypes

var source = [
	{src:"images/bt.jpg", id:"bt"},
	{src:"images/hover.jpg", id:"hover"},
	{src:"images/khoi_000.png", id:"khoi_000"},
	{src:"images/khoi_001.png", id:"khoi_001"},
	{src:"images/khoi_002.png", id:"khoi_002"},
	{src:"images/khoi_003.png", id:"khoi_003"},
	{src:"images/khoi_004.png", id:"khoi_004"},
	{src:"images/khoi_005.png", id:"khoi_005"},
	{src:"images/khoi_006.png", id:"khoi_006"},
	{src:"images/khoi_007.png", id:"khoi_007"},
	{src:"images/khoi_008.png", id:"khoi_008"},
	{src:"images/khoi_009.png", id:"khoi_009"},
	{src:"images/khoi_010.png", id:"khoi_010"},
	{src:"images/khoi_011.png", id:"khoi_011"},
	{src:"images/khoi_012.png", id:"khoi_012"},
	{src:"images/khoi_013.png", id:"khoi_013"},
	{src:"images/khoi_014.png", id:"khoi_014"},
	{src:"images/nen.png", id:"nen"}
];

for(var i in source){
	source[i].src = canvas_url+source[i].src;
}

// library properties:
lib.properties = {
	width: 241,
	height: 126,
	fps: 24,
	color: "#FFFFFF",
	manifest: source
};



// symbols:



(lib.bt = function() {
	this.initialize(img.bt);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,241,126);


(lib.hover = function() {
	this.initialize(img.hover);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,241,126);


(lib.khoi_000 = function() {
	this.initialize(img.khoi_000);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_001 = function() {
	this.initialize(img.khoi_001);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_002 = function() {
	this.initialize(img.khoi_002);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_003 = function() {
	this.initialize(img.khoi_003);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_004 = function() {
	this.initialize(img.khoi_004);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_005 = function() {
	this.initialize(img.khoi_005);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_006 = function() {
	this.initialize(img.khoi_006);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_007 = function() {
	this.initialize(img.khoi_007);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_008 = function() {
	this.initialize(img.khoi_008);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_009 = function() {
	this.initialize(img.khoi_009);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_010 = function() {
	this.initialize(img.khoi_010);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_011 = function() {
	this.initialize(img.khoi_011);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_012 = function() {
	this.initialize(img.khoi_012);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_013 = function() {
	this.initialize(img.khoi_013);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.khoi_014 = function() {
	this.initialize(img.khoi_014);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,352,256);


(lib.nen = function() {
	this.initialize(img.nen);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,241,126);


(lib.Symbol3 = function() {
	this.initialize();

	// Layer 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("rgba(255,255,204,0.008)").s().p("Ay0J2IAAzrMAlpAAAIAATrg");
	this.shape.setTransform(120.5,63);

	this.addChild(this.shape);
}).prototype = p = new cjs.Container();
p.nominalBounds = new cjs.Rectangle(0,0,241,126);


(lib.Symbol2 = function() {
	this.initialize();

	// Layer 1
	this.instance = new lib.nen();

	this.addChild(this.instance);
}).prototype = p = new cjs.Container();
p.nominalBounds = new cjs.Rectangle(0,0,241,126);


(lib.Symbol1 = function() {
	this.initialize();

	// Layer 1
	this.shape = new cjs.Shape();
	this.shape.graphics.rf(["#FFFFFF","rgba(255,255,255,0)"],[0,1],0,0,0,0,0,48).s().p("AiGHMIAAuXIENAAIAAOXg");
	this.shape.setTransform(13.5,46);

	this.addChild(this.shape);
}).prototype = p = new cjs.Container();
p.nominalBounds = new cjs.Rectangle(0,0,27,92.1);


(lib.streamvideo3flv = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Layer 1
	this.instance = new lib.khoi_000();
	this.instance.setTransform(-221.5,-208.7);

	this.instance_1 = new lib.khoi_001();
	this.instance_1.setTransform(-221.5,-208.7);

	this.instance_2 = new lib.khoi_002();
	this.instance_2.setTransform(-221.5,-208.7);

	this.instance_3 = new lib.khoi_003();
	this.instance_3.setTransform(-221.5,-208.7);

	this.instance_4 = new lib.khoi_004();
	this.instance_4.setTransform(-221.5,-208.7);

	this.instance_5 = new lib.khoi_005();
	this.instance_5.setTransform(-221.5,-208.7);

	this.instance_6 = new lib.khoi_006();
	this.instance_6.setTransform(-221.5,-208.7);

	this.instance_7 = new lib.khoi_007();
	this.instance_7.setTransform(-221.5,-208.7);

	this.instance_8 = new lib.khoi_008();
	this.instance_8.setTransform(-221.5,-208.7);

	this.instance_9 = new lib.khoi_009();
	this.instance_9.setTransform(-221.5,-208.7);

	this.instance_10 = new lib.khoi_010();
	this.instance_10.setTransform(-221.5,-208.7);

	this.instance_11 = new lib.khoi_011();
	this.instance_11.setTransform(-221.5,-208.7);

	this.instance_12 = new lib.khoi_012();
	this.instance_12.setTransform(-221.5,-208.7);

	this.instance_13 = new lib.khoi_013();
	this.instance_13.setTransform(-221.5,-208.7);

	this.instance_14 = new lib.khoi_014();
	this.instance_14.setTransform(-221.5,-208.7);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance}]}).to({state:[{t:this.instance_1}]},1).to({state:[{t:this.instance_2}]},1).to({state:[{t:this.instance_3}]},1).to({state:[{t:this.instance_4}]},1).to({state:[{t:this.instance_5}]},1).to({state:[{t:this.instance_6}]},1).to({state:[{t:this.instance_7}]},1).to({state:[{t:this.instance_8}]},1).to({state:[{t:this.instance_9}]},1).to({state:[{t:this.instance_10}]},1).to({state:[{t:this.instance_11}]},1).to({state:[{t:this.instance_12}]},1).to({state:[{t:this.instance_13}]},1).to({state:[{t:this.instance_14}]},1).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-221.5,-208.7,352,256);


(lib.hover_1 = function() {
	this.initialize();

	// Layer 1
	this.instance = new lib.hover();

	this.addChild(this.instance);
}).prototype = p = new cjs.Container();
p.nominalBounds = new cjs.Rectangle(0,0,241,126);


(lib.bt_1 = function() {
	this.initialize();

	// Layer 1
	this.instance = new lib.bt();

	this.addChild(this.instance);
}).prototype = p = new cjs.Container();
p.nominalBounds = new cjs.Rectangle(0,0,241,126);


(lib.nen_1 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Layer 1
	this.instance = new lib.Symbol2();
	this.instance.setTransform(120.5,63,1,1,0,0,0,120.5,63);
	this.instance.alpha = 0;
	this.instance.compositeOperation = "lighter";

	this.timeline.addTween(cjs.Tween.get(this.instance).wait(1).to({alpha:0.05},0).wait(1).to({alpha:0.1},0).wait(1).to({alpha:0.15},0).wait(1).to({alpha:0.2},0).wait(1).to({alpha:0.25},0).wait(1).to({alpha:0.3},0).wait(1).to({alpha:0.35},0).wait(1).to({alpha:0.4},0).wait(1).to({alpha:0.45},0).wait(1).to({alpha:0.5},0).wait(1).to({alpha:0.55},0).wait(1).to({alpha:0.6},0).wait(1).to({alpha:0.545},0).wait(1).to({alpha:0.491},0).wait(1).to({alpha:0.436},0).wait(1).to({alpha:0.382},0).wait(1).to({alpha:0.327},0).wait(1).to({alpha:0.273},0).wait(1).to({alpha:0.218},0).wait(1).to({alpha:0.164},0).wait(1).to({alpha:0.109},0).wait(1).to({alpha:0.055},0).wait(1).to({alpha:0},0).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(0,0,241,126);


(lib.mtg = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Layer 1 (mask)
	var mask = new cjs.Shape();
	mask._off = true;
	mask.graphics.p("ApRF3IgLAAIgKAAIAAgLIgKAAQgEAAgDgCQgCgDgBgFQgEAAgDgCQgCgDgBgFQgEABgDgDQgDgDABgFIAAgJQgFgBgDgCQgDgDABgEQgFgBgDgCQgCgDAAgEQgFgBgDgCQgCgCAAgFQgGAAgCgDQgDgCAAgFQgFAAgCgDQgDgCAAgGQgFAAgCgCQgCgDgBgFIgKAAQgEAAgDgCQgCgDgBgFQgEABgDgDQgDgDABgFIAAgJIAAgKIAJAAIAAgKIAKAAIAKAAIAAgKIAKAAIAAgKIAAgLIAAgKIAKAAIAAgKIAAgKIAAgJIALAAIAAgKIAAgKIAAgKIAAgKIAAgLIAKAAIAAgKIAAgKIAAgKIAAgJIAAgKIgKAAQAAAEgDADQgCACgGABIgKAAQAAAEgCADQgDADgFgBQABAFgDADQgDADgFgBQABAFgDADQgDACgFAAQAAAFgCADQgDACgEAAIgKAAQgBAGgCACQgCADgFAAQAAAFgDACQgCADgFAAQAAAFgDACQgCACgGABQAAAEgCADQgDACgFABIgKAAQABAEgDADQgDACgFABIgKAAIgJAAQgFgBgDgCQgDgDABgEIgKAAIgKAAIAAgKIgLAAQgFgBgCgCQgDgCAAgFIgKAAQgEAAgDgDQgCgCgBgFIgKAAQgEAAgDgDQgDgCABgGQgFAAgDgCQgDgDABgFIgKAAQgFAAgDgCQgCgDAAgFIAAgKIAKAAIAKAAIAKAAIAJAAIAKAAIApAAIAKAAIAKAAIAAgJIAKAAIAJAAIAKAAIAKAAIAAgKIAKAAIAKAAIALAAIAAgKIAKAAIAKAAIAKAAIAAgKIAJAAIAKAAIAAgKIAKAAIAKAAIAAgLIAKAAIALAAIAAgIIAKAAIAKAAIAAgKIAKAAIAAgKIAAgKIAAgJIAAgKIAAgKIAAgKIAAgLIAAgKIAJAAIAAgKIAAgKIAAgKIAAgJIgJAAQgBAEgCADQgDACgEAAIgKAAQAAAFgDADQgCADgFgBIgLAAQAAAFgCADQgDADgFgBIgKAAIgKAAQABAFgDADQgDACgFAAIgJAAQgBAFgCADQgDACgEAAQgBAGgCACQgCADgFAAIgKAAQAAAFgDACQgCADgGAAIgKAAQAAAFgCACQgDACgFABQABAEgDADQgDACgFABQABAEgDADQgDACgFAAIgJAAQgBAFgCADQgDADgEgBQgBAFgCADQgCADgFgBIgKAAIgLAAIgKAAIgKAAIAAgKIgKAAIgKAAIAAgKIgJAAQgFAAgDgCQgDgDABgEQgFgBgDgCQgCgDAAgEQgFgBgDgCQgCgCAAgFIAAgKQgGAAgCgDQgDgCAAgGQgFAAgCgCQgDgDAAgFQgFAAgCgCQgCgDgBgFQgEABgDgDQgCgDgBgFIgKAAIAAgKIAAgJIAAgKIAAgKIAKAAIAAgKIAAgLIAAgKIAKAAIAAgKIAAgKIAAgKIAAgJIAKAAIAAgKIAAgKIAAgKIAKAAIAAgLIALAAIAAgKIAAgKIAKAAIAAgKIAKAAIAAgKIAAgJIAKAAIAAgKIAJAAIAAgKIAAgKIAKAAIAAgLIAKAAIAAgKIAKAAIAAgKIAKAAIAAAKQAAAFgCADQgDACgFAAIAAALQAAAFgCACQgDADgFAAIAAAKIAAAKIAAAJIAAAKIAAAKIAAAKQAFAAADADQACACAAAFQAFAAADADQACACAAAGQAGAAACACQADADAAAFIAKAAIAKAAQAEAAADACQACADABAFIAJAAIAKAAIAKAAIAKAAQAFgBADADQACADAAAFIALAAIAKAAIAKAAIAKAAIAJAAIAKAAIAAgKIAKAAIAKAAIAKAAIALAAIAKAAIAAgKIAKAAIAKAAIAJAAIAKAAIAAgKIAKAAIAKAAIAKAAIAAgLIALAAIAKAAIAKAAIAAgKIAKAAIAJAAIAAgKIAKAAIAKAAIAAgKIAKAAIAKAAIALAAIAAgKIAKAAIAKAAIAAgJIAKAAIAJAAIAAgKIAKAAIAKAAIAAgKIAKAAIAKAAIALAAIAKAAIAKAAIAAgKIAKAAIAJAAQAFAAADACQADADgBAFQAFAAADACQADADgBAFQAFgBADADQACADAAAFIAAAJIAKAAIAAAKIAAAKIAAAKIAAAKIgKAAIAAALIgKAAQABAFgDACQgDADgFAAIgKAAQAAAFgCACQgDACgEABIgKAAIgKAAQAAAEgDADQgCACgFABIgLAAQAAAEgCADQgDACgFAAQAAAFgCADQgDADgFgBQABAFgDADQgDADgFgBQABAFgDADQgDACgFAAQAAAFgCADQgDACgEAAIgKAAIAAgKIAAgKIAKAAIAAgKIAJAAIAAgKIAAgJIgJAAQgBAEgCADQgDACgEAAIgKAAQAAAFgDADQgCADgFgBIgLAAQAAAFgCADQgDADgFgBIgKAAQABAFgDADQgDACgFAAIgKAAIAAAKIgJAAIAAALQgBAFgCACQgDADgEAAIAAAKIAAAKIAAAJIAAAKIAAAKIAAAKIAAAKIgKAAIAAALIAAAKIAAAKIAAAKIAKAAIAKAAIAAgKIAJAAIAKAAIAKAAIAKAAIAAAKIgKAAQABAEgDADQgDACgFAAIgKAAQAAAFgCADQgDADgEgBIgKAAQgBAFgCADQgCADgFgBIgKAAIAAAKIAAAIIAAALIAAAKIAAAKIAAAKIAAAKIAAAJIAAAKIAAAKIAAAKIAAALIAAAKIAAAKIAAAKIAAAKIAAAJIAAAKIAAAKIAAAKIAAALIAAAKIAAAKIAKAAIAKAAIAKAAIAJAAIAKAAIAKAAIAKAAIAKAAIALAAIAKAAIAKAAIAKAAIAAgKIAJAAIAAAKIAAAKIgJAAIAAAKIAJAAIAKAAIAKAAIAAgKIAKAAIAKAAIALAAIAKAAIAAAKIAAAJIgKAAIgLAAIgKAAIAAAKIgKAAIgKAAIgKAAQAAAFgCADQgDACgEAAIgKAAIgKAAIAAAKIgKAAQAAAGgDACQgCADgGAAIgKAAQAAAFgCACQgDADgFAAQABAFgDACQgDACgFABQABAEgDADQgDACgFABQAAAEgCADQgDACgEABQgBAEgCADQgDADgEgBIAAAKQgBAFgCADQgCACgFAAIAAAKIAAALIgKAAgAI0ESQgFAAgCgCQgDgDAAgFIgKAAIgKAAQgEAAgDgCQgCgDAAgFIgKAAIgKAAIgKAAIgKAAIgLAAIgKAAIgKAAIgKAAQgEABgDgDQgCgDAAgFIgKAAIgKAAIgKAAIAAgJIgKAAIAAgKIAKAAIAKAAIAKAAIAKAAIAJAAIAKAAIAKAAIAKAAIAAgKIALAAIAKAAIAAgKIgKAAIgLAAIgKAAIAAAKIgKAAIAAgKIgKAAIAAgKIAKAAIAKAAIAKAAIAAgLIALAAIAKAAIAKAAIAAgKIAKAAIAKAAIAAgKIAJAAIAAgKIAKAAIAKAAIAAgJIAAgKIAAgKIAKAAIAAgKIAAgKIAAgLIAAgKIALAAIAAgKIAAgKIAAgJIAAgKIAAgKIgLAAQAAAEgCADQgDACgFABIgKAAQABAEgDADQgDACgFABIgJAAQgBAEgCADQgDADgEgBIAAAKIAAAKIAAAKQgBAGgCACQgDADgEAAIAAAKQgBAFgCACQgCACgFABIAAAKQAAAEgDADQgCACgFABQAAAEgDADQgCADgGgBQAAAFgCADQgDADgFgBIAAgKIgKAAIAAgJQgEgBgDgCQgCgDgBgEQgEgBgDgCQgCgDAAgEIAAgKIAAgKIAAgLIAAgKIAAgKIAAgKIAJAAIAAgJIAAgKIAAgKIAKAAIAAgKIgKAAIgJAAQgBAFgCACQgDACgEABQgBAEgCADQgDACgEABQgBAEgCADQgCACgFABIAAAJIAAAKIAAAKIAAAKQAAAGgDACQgCADgFAAIAAAKIAAAKIAAAKQAAAEgDADQgCACgGABIgKAAQAAAEgCADQgDADgFgBIgKAAQgEABgDgDQgCgDAAgEIAAgKIgKAAQgBAEgCADQgDACgEABQgBAEgCADQgCADgFgBIgKAAIAAAKIgLAAIgKAAIgKAAIgKAAIgJAAIgKAAIgKAAIgKAAIgKAAIgLAAIgKAAIgKAAQgEABgDgDQgCgDgBgFIgJAAQgBAFgCADQgDADgEgBQgFABgDgDQgDgDABgFQgFABgDgDQgCgDAAgEIAAgKIAKAAIAAgKIAAgKIAKAAIAAgKIAKAAIAAgLIAJAAIAAgKIAKAAIAKAAIAKAAIAAgKIgKAAIgKAAIgKAAQgEABgDgDQgCgDAAgFIAAgJIAAgKIgKAAIAAAKIgKAAIAAAJIAAAKQgBAFgCADQgCACgFAAIAAAKIAAALQAAAFgDACQgCADgFAAIAAAKQAAAEgDADQgCACgGABIAAAKIgKAAIAAAJQAAAFgCADQgDADgFgBQABAFgDADQgDACgFAAQABAFgDADQgDACgEAAQgBAGgCACQgDADgEAAQgBAFgCACQgDADgEAAQgBAFgCACQgCACgFABQAAAEgDADQgCACgFABQAAAEgDADQgCACgGABIAAAFQgEgBgGgEIAAgKIAKAAIAAgKIAAgKIAAgKIAAgLIgKAAQAAAGgCACQgDADgFAAIgIAAIgKAAIgJAAIAAAEQgFAAgFgEIgKAAIgKAAIAAAKIgLAAIAAAKIgKAAIAAAKIgKAAIgKAAIgKAAQAAAEgCADQgDACgEABIgKAAIAAgKIgKAAIgKAAIgLAAQgFgBgCgCQgDgDAAgEQgFgBgCgCQgCgCgBgFIgKAAQgEAAgDgDQgCgCgBgFQgEAAgDgDQgDgCABgGQgFAAgDgCQgDgDABgFIAAgKIAAgKQgFABgDgDQgCgDAAgEIAAgKIAAgKIAAgKIAAgKIAAgLIgKAAQAAAGgDACQgCADgGAAQAAAFgCACQgDADgFAAQAAAFgCACQgDACgFABIAAAKQABAEgDADQgDACgFABIAAAJIAAAKQABAFgDADQgDACgFAAQAAAFgCADQgDACgEAAQgFAAgDgCQgDgDABgFIAAgKQgFABgDgDQgCgDAAgFIAAgJIAAgKIgKAAQAAAEgDADQgCACgGABIgKAAQAAAEgCADQgDADgFgBQABAFgDADQgDADgFgBQABAFgDADQgDACgFAAIgJAAIgKAAQgFAAgDgCQgCgDAAgFIgKAAQgGABgCgDQgDgDAAgFIgKAAIgKAAIgKAAIgKAAIgJAAIAAAKIgKAAIgKAAIgKAAIgLAAIgKAAIgKAAQgEABgDgDQgCgDgBgFIgKAAQAAAFgCADQgDADgEgBQgFABgDgDQgDgDABgFQgFABgDgDQgCgDAAgEIAAgKIAKAAIAAgKIAAgKIAAgKIAKAAIAAgLIAJAAIAAgKIAKAAIAKAAIAAgKIAKAAIAKAAIALAAIAAgKIgLAAIgKAAIgKAAIgKAAIgKAAQgEABgDgDQgDgDABgEQgFgBgDgCQgDgDABgEIAAgKIAAgKIAKAAIAAgKIAAgLIAJAAIAAgIIAKAAIAAgKIAKAAIAKAAIAAgKIAKAAIALAAIAAgKIAKAAIAAgJIAKAAIAKAAIAJAAIAKAAIAAgKIAKAAIAKAAIAKAAIAAgKIAAgKIALAAIAAgLIAKAAIAAgKIAKAAIAAgKIAKAAIAAgKIgKAAIAAAKIgKAAIAAAKIgKAAIgLAAQgFAAgCgCQgDgDAAgFIgKAAIAAgKIgKAAIAAgKIAKAAIAAgJIAKAAIAAgKIAKAAIAAgKIALAAIAKAAIAAgKIAKAAIAKAAIAJAAIAAgLIAKAAIAKAAQAFAAADADQACACAAAGIAAAKQAFAAADACQACADAAAFIAAAKIAAAJIAAAKQAAAFgCADQgDADgFgBQAAAFgCADQgDACgFAAIgKAAQABAFgDADQgDACgFAAQAAAGgCACQgDADgEAAIgKAAQgBAFgCACQgCADgFAAIgKAAIAAAKIAKAAQAFgBACADQACADABAFIAKAAIAJAAQAFgBADADQADADgBAEQAFABADACQADADgBAEIAAAKIAAAKIAAAIQABAGgDACQgDADgFAAIAAAKIAAAKIAAAKIAAAKQABAEgDADQgDADgFgBIAAAKIAAAKIAAAKIAAALIAAAKIAAAKIAKAAIAKAAIAKAAIAKAAIALAAIAAgKIAAgKIAAgLIAAgKIgLAAIAAgKIAAgKQgFABgCgDQgDgDAAgEQgFgBgCgCQgCgDgBgEIAAgKIAKAAIAAgKIAAgKIAKAAIAAgLIALAAIAAgIIAKAAIAAgKIAKAAIAKAAIAAgKIAJAAIAKAAIAAgKIAKAAIAKAAQAFABADACQACADAAAEQAGABACACQADADAAAEIAAAKIAAAIQAAAGgDACQgCADgGAAIAAAKIAAAKQAAAEgCADQgDACgFABIAAAKQAAAEgCADQgDADgFgBIAAAKIAAAKIAAAKIAKAAIAAgKIAKAAIALAAIAAgKIAKAAIAKAAIAAgKIAAgJIAAgKIAAgKIAKAAIAAgKIAAgKIAAgLIAJAAIAAgIIAAgKIAKAAIAAgKIAKAAIAAgKIAAgJIAKAAIAAgKIAKAAIAAgKIAAgKIALAAIAAgLIAKAAIAAgKIAKAAIAAgKIAKAAIAAgKIAJAAIAAgKIAKAAIAAgJIAKAAIAAgKIAKAAIAAgKIAKAAIAAgKIALAAIAAgLIAKAAIAAgKIAKAAIAKAAIAAgKIAJAAIAAgKIAKAAIAAgKIAAgJIAAgKIAAgKIgKAAQgEAAgDgDQgDgCABgFQgFAAgDgDQgDgCABgGIgKAAIAAgKIgKAAIgLAAIAAgKQgFABgCgDQgDgDAAgFIgKAAQgEABgDgDQgCgDgBgFIAAgJIAKAAQAFgBADADQACADAAAEQAFABADACQACADAAAEIALAAIAKAAIAAAKIAKAAIAAgKIgKAAIAAgKIAKAAIAAAKIAKAAIAJAAIAKAAQAEABACACQADADgBAEIAKAAIAKAAIALAAIAKAAIAKAAIAAAKIAKAAIAKAAIAJAAIAKAAQAFAAADADQACACAAAFIAKAAIALAAQAFAAACADQADACAAAGIAKAAQAEAAADACQACADABAFQAEAAADACQACADABAFIAJAAQAFgBADADQADADgBAFQAFgBADADQACADAAAEQAFABADACQACADAAAEQAGABACACQADADAAAEIAAAKIAAAKIAAALIAAAKIAAAKIAAAKIAAAJQAAAFgDADQgCADgGgBQAAAFgCADQgDADgFgBQAAAFgCADQgDACgFAAQABAFgDADQgDACgFAAQABAGgDACQgDADgEAAQgBAFgCACQgDADgEAAQgBAFgCACQgDACgEABQgBAEgCADQgCACgFABIgKAAIgLAAQAAAEgCADQgDACgFAAIgKAAIgKAAIgJAAIgKAAIgKAAIAAAKIgKAAIgKAAQgGABgCgDQgDgDAAgFIAAgJIAAgKIgKAAIgKAAQABAEgDADQgCACgEABIgKAAQAAAEgCADQgDACgEAAIgKAAQgBAFgCADQgCADgFgBIgKAAQAAAFgDADQgCADgGgBQAAAFgCADQgDACgFAAQAAAEgCACQgDACgFAAQABAGgDACQgDADgFAAQABAFgDACQgDADgFAAIAAAKIgJAAIAAAKIAAAKIgKAAIAAAJIAAAKIAAAKIAAAKIAAALIAAAKQAEAAADACQACADABAFQAEgBADADQACADAAAFIAKAAIAKAAIAKAAIAKAAIALAAIAKAAIAKAAIAKAAIAAgKIAJAAIAKAAIAIAAIAAgKIAKAAIAKAAIALAAIAAgKIAKAAIAAgLIAKAAIAAgKIAAgKIgKAAIgKAAQAAAFgDADQgCACgGAAIgKAAQAAAFgCADQgDACgFAAIgIAAIgKAAQgEAAgDgCQgDgDABgFQgFAAgDgCQgDgDABgFIAAgKIAAgJIAAgKIAAgKIAAgKIAAgKIAKAAIAAgLIAJAAIAKAAIAIAAIAKAAIAKAAIALAAIAKAAIAAgIIAKAAIAKAAIAKAAIAJAAIAKAAIAKAAIAKAAIAAgKIALAAIAKAAIAKAAIAKAAIAKAAIAJAAIAKAAIAKAAIAKAAIALAAIAKAAIAAgKIAKAAIAKAAIAKAAIAAgKIAJAAIAKAAIAKAAIAAgJIAKAAIALAAQAFgBACADQADADAAAEQAFABACACQACADABAEQAEABADACQACADABAEIAAAKIAKAAIAAgKIAJAAIAAgKIAKAAIAAgKIAKAAQAFABADACQACADAAAEIAAAKQAGABACACQADACAAAFIAAAIIAAALIAKAAIAKAAIAAgLIAKAAIAAgIIAKAAIAAgKIAJAAIAKAAIAAgKIAKAAIAAgKIAKAAIALAAIAAgJIAKAAIAKAAIAKAAIAKAAIAAAJIAJAAIAAAKIAAAKIAAAKIAAAIIAKAAIAKAAIAKAAIAAgIIALAAIAAgKIAKAAIAKAAIAAgKIAKAAIAKAAIAJAAQAFABADACQADADgBAEQAFABADACQACACAAAFQAFAAADADQACABAAAEQAGAAACADQADACAAAGIAAAKQAFAAACACQADADAAAFIAKAAIAKAAIAAgKIAAgKIAAgLIAKAAIAAgIIAAgKIAJAAIAAgKIAKAAIAKAAIAAgKIAKAAIAAgJIALAAIAKAAIAAgKIAKAAIAKAAIAAgKIAKAAIAJAAIAKAAIAKAAIAKAAIALAAQAFAAACACQADADAAAFIAKAAQAEgBADADQACADABAFIAKAAIAAAJIAJAAIAAAKQAFABADACQADADgBAEIAAAKIAAAIIAAALQABAFgDACQgDADgFAAIAAAKQABAEgDADQgDACgEABQgBAEgCADQgDACgEABIgKAAQgBAEgCADQgCADgFgBIgKAAQAAAFgDADQgCADgGgBIgKAAQAAAFgCADQgDACgFAAIgKAAIgJAAQgBAFgCADQgDACgEAAIgKAAIAAALQAEAAADACQACADABAFQAEAAADACQACADABAFIAJAAIAKAAIAKAAIAKAAIALAAIAKAAIAKAAIAKAAIAKAAIAJAAIAAgKIAKAAIAKAAIAAgKIAKAAIALAAIAAgLIAKAAIAKAAIAAgKIAKAAIAAgKIAKAAIAAgKIAJAAIAAgJIAKAAIAAgKIAAgKIAKAAIAAAKIAAAKIAAAJIAAAKIgKAAIAAAKIgKAAIAAAKIgJAAIAAALIAJAAIAAAKIAAAKIgJAAIAAAKIgKAAQgBAEgCADQgDACgEABQgBAEgCADQgCADgFgBQAAAFgDADQgCADgFgBQAAAFgDADQgCACgGAAQAAAFgCADQgDACgFAAIgKAAIgKAAQABAGgDACQgDADgEAAIgKAAIgKAAIgKAAQAAAFgDACQgCADgFAAIgLAAIgKAAIgKAAQgEAAgDgDQgCgCgBgFIgJAAIgKAAIgKAAIgKAAQgFAAgDgDQgCgCAAgGIgLAAQgFAAgCgCQgDgDAAgFQgFAAgCgCQgCgDgBgFQgEABgDgDQgCgDgBgFQgEABgDgDQgCgDAAgEQgFgBgDgCQgDgDABgEIAAgKQgFgBgDgCQgDgCABgFIAAgKIAAgLIAAgKIAAgKIAAgKIAAgJIgKAAIAAAJIAAAKIAAAKIAAAKIAAALIAAAKIAAAKQAAAEgDADQgCACgFABIAAAKIAAAJIAAAKQAAAFgDADQgCACgGAAIAAAKIAAALIAAAKQAAAFgCACQgDACgFABIAAAKIAAAKQAAAEgCADQgDADgFgBQABAFgDADQgDADgFgBQABAFgDADQgDACgEAAIgKAAIgKAAIgKAAQAAAFgDADQgCACgFAAIgLAAgAiaDNIALAAIAAgKIgLAAIAAAKgAiuDDIAKAAIAAgLIgKAAIAAALgAi4C4IAKAAIAAgKIgKAAIAAAKgAjLB9IAAAKIAAAKIAAAJIAJAAIAAAKIAAAKIAKAAIAAgKIAAgKIgKAAIAAgJIAAgKIAAgKIAAgKIgJAAIAAAKgAoYBwQgDADgFAAIAAAKIAAAKIAKAAIAAgKIAKAAIAKAAIALAAIAKAAIAAgKIAKAAIAKAAIAAgKIAJAAIAAgLIAAgKIgJAAIgKAAQgBAFgCADQgCACgFAAIgKAAIgLAAQAAAGgCACQgDADgFAAIgKAAQABAFgDACgAFMAqQgDACgEABIAAAKIAAAJIAAAKIAAAKIAAAKIAAALIAAAKIAAAKIAKAAIAAgKIAAgKIAAgLIAAgKIAAgKIAAgKIAKAAIAAgJIAAgKIAAgKIgKAAQgBAEgCADgAkSBpIAKAAIAAgLIgKAAIAAALgADoAgQgCACgFABQAAAEgDADQgCACgFABIAAAKIAAAJIAAAKIAKAAIAKAAIAAgKIAKAAIAKAAIAAgJQgFgBgDgCQgDgDABgEIAAgKIAAgKIgKAAQgBAFgCACgAoCAjQAGgBACADQADADAAAFIAKAAIAAAKIAAAJIAKAAIAKAAIAAgJIAJAAIAKAAIAAgKIAKAAIAAgKIAAgKQgEAAgDgDQgCgCgBgFIgKAAIgJAAIgKAAIgKAAIAAAKIgKAAIgLAAIAAAKgAMbAjIAJAAIAKAAIAKAAIAKAAIAAgKIAAgKIgKAAIgKAAQABAFgDACQgDADgFAAIgJAAIAAAKgAAYjpIALAAIAAgKIgLAAIAAAKgAgOkIIAKAAIAAALIAIAAIAAgLIgIAAIAAgKIgKAAIAAAKgAMnBwQgCgCgBgFIAKAAIAAAKQgEAAgDgDgAlBgkQgCgDAAgEIAAgKIAAgKIAAgKIAAgLIAKAAIAAgKIAAgKIAAgKIAKAAIAAgKIAAgJIAAgKIAKAAIAJAAIAAgKIAKAAIAKAAIAAgKIAKAAIAKAAIALAAQAFAAACACQADADAAAFQAFAAACACQACADABAFQAEgBADADQACADABAFIAAAJIAAAKIAJAAIAAAKIgJAAIAAAKIAAAKQgBAGgCACQgDADgEAAQgBAFgCACQgCADgFAAIgKAAQAAAFgDACQgCACgGABIgKAAIgKAAIgKAAQABAEgDADQgDACgFABIgJAAIgKAAQgBAEgCADQgCACgFAAQgFAAgDgCg");
	mask.setTransform(100.5,39.5);

	// Layer 2
	this.instance = new lib.Symbol1();
	this.instance.setTransform(-26.6,-7.9,0.997,1.711,29.9,0,0,13.7,46);
	this.instance.compositeOperation = "lighter";
	this.instance.filters = [new cjs.BlurFilter(37, 37, 1)];
	this.instance.cache(-2,-2,31,96);

	this.instance.mask = mask;

	this.timeline.addTween(cjs.Tween.get(this.instance).wait(1).to({regX:13.5,scaleX:1,scaleY:1.72,rotation:30,x:-20.1,y:-6},0).wait(1).to({scaleY:1.72,x:-13.4,y:-4.1},0).wait(1).to({scaleY:1.72,x:-6.7,y:-2.1},0).wait(1).to({scaleY:1.72,x:0,y:-0.1},0).wait(1).to({scaleY:1.72,x:6.7,y:1.9},0).wait(1).to({scaleY:1.73,x:13.4,y:3.9},0).wait(1).to({scaleY:1.73,x:20.1,y:5.8},0).wait(1).to({scaleY:1.73,x:26.8,y:7.8},0).wait(1).to({scaleY:1.73,x:33.6,y:9.8},0).wait(1).to({scaleY:1.74,x:40.3,y:11.7},0).wait(1).to({scaleY:1.74,x:47,y:13.7},0).wait(1).to({scaleY:1.74,x:53.7,y:15.7},0).wait(1).to({scaleY:1.74,x:60.4,y:17.7},0).wait(1).to({scaleY:1.74,x:67.1,y:19.6},0).wait(1).to({scaleY:1.75,x:73.8,y:21.6},0).wait(1).to({scaleY:1.75,x:80.5,y:23.6},0).wait(1).to({scaleY:1.75,x:87.2,y:25.6},0).wait(1).to({scaleY:1.75,x:93.9,y:27.6},0).wait(1).to({scaleY:1.75,x:100.6,y:29.6},0).wait(1).to({scaleY:1.76,x:107.4,y:31.5},0).wait(1).to({scaleY:1.76,x:114.1,y:33.5},0).wait(1).to({scaleY:1.76,x:120.8,y:35.5},0).wait(1).to({scaleY:1.76,x:127.5,y:37.4},0).wait(1).to({scaleY:1.77,x:134.2,y:39.4},0).wait(1).to({scaleY:1.77,x:140.9,y:41.4},0).wait(1).to({scaleY:1.77,x:147.6,y:43.3},0).wait(1).to({scaleY:1.77,x:154.3,y:45.3},0).wait(1).to({scaleY:1.77,x:161,y:47.3},0).wait(1).to({scaleY:1.78,x:167.7,y:49.3},0).wait(1).to({scaleY:1.78,x:174.4,y:51.3},0).wait(1).to({scaleY:1.78,x:181.1,y:53.2},0).wait(1).to({scaleY:1.78,x:187.9,y:55.2},0).wait(1).to({scaleY:1.78,x:194.6,y:57.2},0).wait(1).to({scaleY:1.79,x:201.3,y:59.2},0).wait(1).to({scaleY:1.79,x:208,y:61.2},0).wait(1).to({scaleY:1.79,x:214.7,y:63.1},0).wait(1).to({scaleY:1.79,x:221.5,y:65.1},0).wait(1).to({scaleY:1.79,x:228.2,y:67.1},0).wait(1).to({scaleY:1.8,x:234.9,y:69},0).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(0,2,68.3,75);


(lib.mdow = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Layer 1 (mask)
	var mask = new cjs.Shape();
	mask._off = true;
	mask.graphics.p("AHlBLIgKAAIgKAAIg9AAIgJAAIgKAAIgKAAIgfAAIgKAAIAAgKIAKAAIAAgLIAAgKIAAgKIAAgKIgKAAIgdAAIAAAKQgBAFgCADQgDACgEAAIAAAKIAAALQAEAAADACQACADABAFIgKAAIgKAAIgUAAIgLAAIAAgKIALAAIAAgLIAKAAIAAgKIAAgKIAAgKIAKAAIAAgJIAAgKIAAgIIAAgKIAKAAIAAgKIAAgLIAAgKIAAgKIAKAAIAAgKIAAgKIAJAAIAKAAIAKAAIAKAAIAAAKIAAAKIAAAKIAAAKQAGAAACADQADACAAAGIAAAKIAAAKIAAAIQAFgBACADQADADAAAFIAAAJIAAAKQAFABACACQACACABAFIAAAKIAAALIAKAAIAKAAIAAgLIAJAAIAAgKIAAhsQgEABgDgDQgCgDAAgFIAJAAIBHAAIAKAAIAJAAIAAAKIAKAAIAAAKIAAAKIAABOIAAAKIAAAKIAAALIgKAAIAAAKIgJAAgAGyA2IAAALIAVAAIAKAAIAAgLIAKAAIAAgKIAAhiIAAgKIgKAAIgfAAIAAB2gAE6gXIAAAKIAAAKQABADgDACQgDACgEABIAAAKIATAAIAKAAIAAgKIAAgIIAAgKQgFAAgCgDQgCgCgBgFIAAgLIgKAAIAAALgADqBLIgKAAIgJAAIgoAAIgLAAIgKAAIAAgKIAAgLIAAgKIAAhiIAAgKIAAgKIAKAAIALAAIAoAAIAJAAIAKAAIAKAAIAAAKIAAAKIAABiIAAAKIAAALIAAAKIgKAAgAC2g4QgCADgFgBIAABiIAAAKQAFAAACADQADACAAAGIAUAAIAKAAIAAgLIAJAAIAAgKIAAgKIAAhYIAAgKIgJAAIgeAAQAAAFgDADgACGBLIgJAAIhHAAIgKAAIAAgKIAKAAIAAgLIAAh2QgEABgDgDQgCgDgBgFIAKAAIAUAAIALAAIAKAAQAAAFgDADQgCADgFgBIAAB2IAAALIAUAAIAKAAIAAgLIAAgUIAKAAIAJAAQARADgGAcIgBAKIgKAAgAAPBLIgKAAIgIAAIAAgKQgGAAgCgDQgDgCAAgGIAAgKQgFAAgCgCQgDgDAAgFIAAgKQgFABgCgDQgCgDgBgEIAAgKQgEgBgDgCQgCgCgBgDIAAgKIgKAAIAABDIAAALQAFAAADACQADADgBAFIgKAAIgJAAIgUAAIgKAAIAAgKIAKAAIAAgLIAAh2IgKAAIgLAAIgKAAIAAAKIAAAKIAAAKIAAALQAAAFgCACQgDADgFAAIAAAKIAAAIIAAAKIAAAJIAAAKQABAFgDADQgDACgFAAIAAAKIAAALIAAAKIgKAAIgJAAIgKAAIAAgKIAAgLQgFAAgDgCQgCgDAAgFIAAgKIAAgKIAAgJIAAgKQgFgBgDgCQgCgCAAgDIgLAAIAAAIIAAAKIAAAJIAAAKQAAAFgCADQgDACgFAAIAAAKIAAALIAAAKIgKAAIgKAAIgKAAIAAgKIAAgLQgEAAgDgCQgDgDABgFIAAgKIAAgKIAAgJIAAgKIAAgIQgFgBgDgCQgDgCABgFIAAgKIAAgLIAAgKIAAgKQgFABgDgDQgCgDAAgFQgFABgDgDQgCgDAAgFIAKAAIAUAAIAJAAIAKAAQABAFgDADQgDADgFgBIAAAKIAAAKIAAAKIAAALQAFAAADACQADADgBAFIAAAKIAAAIIAAAKIAAAJIAKAAIAAgJIAAgKIAAgIIAAgKIAAgKIAAgLIAKAAIAAgKIAAgKIAAgKIAAgKIAKAAIALAAIAKAAIAKAAIAAAKIAAAKIAAAKIAAAKIAAALQAEAAADACQACADABAFIAAAKIAAAIIAAAKIAJAAIAAgKIAAgIIAAgKIAAgKIAAgLIAKAAIAAgKIAAgKIAAgKQgEABgDgDQgCgDgBgFIAKAAIAUAAIAKAAIALAAIAKAAIAKAAIAKAAIAJAAIAKAAIAAAKIAAAKQAFABADACQADACgBAFIAAAKQAFAAADADQACACAAAGIAAAKIAAAKQAFgBADADQACABAAAFIAAAKIALAAIAAgKIAAhFQgGABgCgDQgDgDAAgFIALAAIASAAIAKAAIAKAAQgBAFgCADQgDADgEgBIAACBIAAAKIgKAAgAkmBLIgKAAIgKAAIgxAAIgLAAIAAgKIAAgLIgEAAQgFg2gBg2IAKAAIAAgKIAAgKIALAAIAxAAIAKAAIAKAAIAKAAIAAAKIAAAKIAABiIAAAKIAAALIAAAKIgKAAgAlhg2IAABiIAAAKIAAALIAdAAIAKAAIAAgLIAKAAIAAgKIAAhiQgEABgDgDQgCgDgBgFIgKAAIgdAAIAAAKgAmeBLIgJAAIhHAAQgEAAgDgDQgCgCgBgFIAAgLIAKAAIAAgKIAAhsIgKAAIAAgKIAKAAIBHAAIAJAAIAKAAIAAAKQAFABADACQADADgBAEIAAAKIAABOIAAAKIAAAKQABAGgDACQgDADgFAAIAAAKIgKAAgAnQA2IAAALIAVAAIAKAAIAAgLIAKAAIAAgKIAAhiIAAgKIgKAAIgfAAIAAB2g");
	mask.setTransform(50.5,7.5);

	// Layer 2
	this.instance = new lib.Symbol1();
	this.instance.setTransform(-26.6,-8,0.999,0.999,29.9,0,0,13.7,46);
	this.instance.filters = [new cjs.BlurFilter(37, 37, 1)];
	this.instance.cache(-2,-2,31,96);

	this.instance.mask = mask;

	this.timeline.addTween(cjs.Tween.get(this.instance).wait(1).to({regX:13.5,scaleX:1,scaleY:1,rotation:30,x:-22.4,y:-7.1},0).wait(1).to({x:-18,y:-6.1},0).wait(1).to({x:-13.6,y:-5.2},0).wait(1).to({x:-9.3,y:-4.2},0).wait(1).to({x:-5,y:-3.3},0).wait(1).to({x:-0.6,y:-2.3},0).wait(1).to({x:3.8,y:-1.4},0).wait(1).to({x:8.1,y:-0.4},0).wait(1).to({x:12.5,y:0.5},0).wait(1).to({x:16.8,y:1.5},0).wait(1).to({x:21.2,y:2.4},0).wait(1).to({x:25.6,y:3.4},0).wait(1).to({x:29.9,y:4.3},0).wait(1).to({x:34.3,y:5.3},0).wait(1).to({x:38.6,y:6.2},0).wait(1).to({x:43,y:7.2},0).wait(1).to({x:47.4,y:8.1},0).wait(1).to({x:51.7,y:9.1},0).wait(1).to({x:56.1,y:10},0).wait(1).to({x:60.4,y:11},0).wait(1).to({x:64.8,y:11.9},0).wait(1).to({x:69.2,y:12.9},0).wait(1).to({x:73.5,y:13.8},0).wait(1).to({x:77.9,y:14.8},0).wait(1).to({x:82.2,y:15.7},0).wait(1).to({x:86.6,y:16.7},0).wait(1).to({x:91,y:17.6},0).wait(1).to({x:95.3,y:18.6},0).wait(1).to({x:99.7,y:19.5},0).wait(1).to({x:104,y:20.5},0).wait(1).to({x:108.4,y:21.4},0).wait(1).to({x:112.8,y:22.4},0).wait(1).to({x:117.1,y:23.3},0).wait(1).to({x:121.5,y:24.3},0).wait(1).to({x:125.8,y:25.2},0).wait(1).to({x:130.2,y:26.2},0).wait(1).to({x:134.6,y:27.1},0).wait(1).to({x:138.9,y:28.1},0).wait(1).to({x:143.3,y:29},0).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(0,0,51.7,15);


(lib.nuttaigame = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// timeline functions:
	this.frame_0 = function() {
		this.stop();
	}
	this.frame_1 = function() {
		this.stop();
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).call(this.frame_0).wait(1).call(this.frame_1).wait(1));

	// Layer 2
	this.instance = new lib.streamvideo3flv();
	this.instance.setTransform(158.2,76.6,0.503,0.341,0,0,0,-44.4,2.5);
	this.instance.compositeOperation = "lighter";

	this.instance_1 = new lib.streamvideo3flv();
	this.instance_1.setTransform(91.8,63.4,0.503,0.341,0,0,0,-44.5,2.5);
	this.instance_1.compositeOperation = "lighter";

	this.instance_2 = new lib.streamvideo3flv();
	this.instance_2.setTransform(207.6,50.9,0.471,0.32,29.5,0,0,-45.5,-81.2);
	this.instance_2.compositeOperation = "lighter";

	this.instance_3 = new lib.streamvideo3flv();
	this.instance_3.setTransform(36.3,50.1,0.511,0.347,-39.2,0,0,-45.5,-80.7);
	this.instance_3.compositeOperation = "lighter";

	this.instance_4 = new lib.streamvideo3flv();
	this.instance_4.setTransform(158.2,138.1,0.503,0.341,0,0,0,-44.4,2.5);
	this.instance_4.compositeOperation = "lighter";

	this.instance_5 = new lib.streamvideo3flv();
	this.instance_5.setTransform(96.8,135.9,0.503,0.341,0,0,0,-44.5,2.5);
	this.instance_5.compositeOperation = "lighter";

	this.instance_6 = new lib.streamvideo3flv();
	this.instance_6.setTransform(297.1,158.4,0.406,0.276,0,0,0,174.8,123.7);
	this.instance_6.compositeOperation = "lighter";

	this.instance_7 = new lib.streamvideo3flv();
	this.instance_7.setTransform(119.1,157.2,0.406,0.276,0,0,0,175.1,123.7);
	this.instance_7.compositeOperation = "lighter";

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_3,p:{regX:-45.5,regY:-80.7,scaleX:0.511,scaleY:0.347,rotation:-39.2,skewX:0,x:36.3,y:50.1}},{t:this.instance_2,p:{regX:-45.5,regY:-81.2,scaleX:0.471,scaleY:0.32,rotation:29.5,skewX:0,x:207.6,y:50.9}},{t:this.instance_1,p:{scaleY:0.341,skewX:0,x:91.8,y:63.4}},{t:this.instance,p:{scaleY:0.341,skewX:0,y:76.6}}]}).to({state:[{t:this.instance_7},{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3,p:{regX:175.1,regY:123.5,scaleX:0.406,scaleY:0.272,rotation:0,skewX:180,x:119.1,y:-41.9}},{t:this.instance_2,p:{regX:174.8,regY:123.7,scaleX:0.406,scaleY:0.272,rotation:0,skewX:180,x:297.1,y:-43.1}},{t:this.instance_1,p:{scaleY:0.337,skewX:180,x:96.8,y:-20.9}},{t:this.instance,p:{scaleY:0.337,skewX:180,y:-23.1}}]},1).wait(1));

	// nen
	this.instance_8 = new lib.nen_1();
	this.instance_8.setTransform(120.5,63,1,1,0,0,0,120.5,63);
	this.instance_8._off = true;

	this.timeline.addTween(cjs.Tween.get(this.instance_8).wait(1).to({_off:false},0).wait(1));

	// m tg
	this.instance_9 = new lib.mtg();
	this.instance_9.setTransform(120.5,54.5,1,1,0,0,0,100.5,38.5);

	this.timeline.addTween(cjs.Tween.get(this.instance_9).wait(1).to({y:57.5},0).wait(1));

	// m dow
	this.instance_10 = new lib.mdow();
	this.instance_10.setTransform(122.5,97.5,1,1,0,0,0,50.5,7.5);

	this.timeline.addTween(cjs.Tween.get(this.instance_10).wait(2));

	// hover
	this.instance_11 = new lib.hover_1();
	this.instance_11.setTransform(120.5,63,1,1,0,0,0,120.5,63);
	this.instance_11._off = true;

	this.timeline.addTween(cjs.Tween.get(this.instance_11).wait(1).to({_off:false},0).wait(1));

	// bt
	this.instance_12 = new lib.bt_1();
	this.instance_12.setTransform(120.5,63,1,1,0,0,0,120.5,63);

	this.timeline.addTween(cjs.Tween.get(this.instance_12).to({_off:true},1).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-76.7,-86,376.5,237.4);


// stage content:



(lib.Taigame = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// timeline functions:
	this.frame_0 = function() {
		var mybtn, mytaigame;
		
		mybtn = this.btn;
		mytaigame = this.taigame;
		mybtn.cursor = "pointer";
		mybtn.addEventListener("click", function(){calltg(); });
		mybtn.addEventListener("mouseover", function(){mytaigame.gotoAndPlay(1);});
		mybtn.addEventListener("mouseout", function(){mytaigame.gotoAndPlay(0);});
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).call(this.frame_0).wait(1));

	// Layer 2
	this.btn = new lib.Symbol3();
	this.btn.setTransform(120.5,63,1,1,0,0,0,120.5,63);

	this.timeline.addTween(cjs.Tween.get(this.btn).wait(1));

	// Layer 1
	this.taigame = new lib.nuttaigame();
	this.taigame.setTransform(120.5,63,1,1,0,0,0,120.5,63);

	this.timeline.addTween(cjs.Tween.get(this.taigame).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(43.8,-23,376.5,237.4);

})(lib_btn = lib_btn||{}, images = images||{}, createjs = createjs||{}, ss = ss||{});
var lib_btn, images, createjs, ss;