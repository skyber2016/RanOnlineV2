var canvas,
    stage,
    stage2,
    stage3,
    stage4,
    stage5,
    stage6,
    stage7,
    stage8,
    stage9,
    stage10,
    stage11,
    stage12,
    stage13,
    stage14,
    stage15,
    stage16,
    stage17,
    stage18,
    stage19,
    stage20,
    stage21,
    stagebutton,
    exportRoot;

function init() {
    console.log("init page");
    canvas = document.getElementById("canvas");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad);
    loader.addEventListener("complete", handleComplete);
    loader.loadManifest(lib.properties.manifest);
}

function handleFileLoad(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete(evt) {
    exportRoot = new lib.FULLvideo();

    stage = new createjs.Stage(canvas);
    stage.addChild(exportRoot);
    stage.update();
    stage.enableMouseOver(24);
    createjs.Ticker.setFPS(lib.properties.fps);
    createjs.Ticker.addEventListener("tick", stage);
    init2();
}

function init2() {
    canvas = document.getElementById("canvas_vodang");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad2);
    loader.addEventListener("complete", handleComplete2);
    loader.loadManifest(lib_vd.properties.manifest);
}

function handleFileLoad2(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete2(evt) {
    exportRoot = new lib_vd.Vodang();

    stage2 = new createjs.Stage(canvas);
    stage2.addChild(exportRoot);
    stage2.update();
    stage2.enableMouseOver(24);

    createjs.Ticker.addEventListener("tick", stage2);
    init3();
}

function init3() {
    canvas = document.getElementById("canvas_ngami");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad3);
    loader.addEventListener("complete", handleComplete3);
    loader.loadManifest(lib_ngami.properties.manifest);
}

function handleFileLoad3(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete3(evt) {
    exportRoot = new lib_ngami.NgaMi();

    stage3 = new createjs.Stage(canvas);
    stage3.addChild(exportRoot);
    stage3.update();
    stage3.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_ngami.properties.fps);
    createjs.Ticker.addEventListener("tick", stage3);
    init4();
}

function init4() {
    canvas = document.getElementById("canvas_caibang");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad4);
    loader.addEventListener("complete", handleComplete4);
    loader.loadManifest(lib_caibang.properties.manifest);
}

function handleFileLoad4(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete4(evt) {
    exportRoot = new lib_caibang.Caibang();

    stage4 = new createjs.Stage(canvas);
    stage4.addChild(exportRoot);
    stage4.update();
    stage4.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_caibang.properties.fps);
    createjs.Ticker.addEventListener("tick", stage4);
    init5();
}

function init5() {
    canvas = document.getElementById("canvas_duongmon");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad5);
    loader.addEventListener("complete", handleComplete5);
    loader.loadManifest(lib_duongmon.properties.manifest);
}

function handleFileLoad5(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete5(evt) {
    exportRoot = new lib_duongmon.DuongMon();

    stage5 = new createjs.Stage(canvas);
    stage5.addChild(exportRoot);
    stage5.update();
    stage5.enableMouseOver(24);
    createjs.Ticker.setFPS(lib_duongmon.properties.fps);
    createjs.Ticker.addEventListener("tick", stage5);
    init6();
}

function init6() {
    canvas = document.getElementById("canvas_camyve");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad6);
    loader.addEventListener("complete", handleComplete6);
    loader.loadManifest(lib_camyve.properties.manifest);
}

function handleFileLoad6(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete6(evt) {
    exportRoot = new lib_camyve.CamYve();

    stage6 = new createjs.Stage(canvas);
    stage6.addChild(exportRoot);
    stage6.update();
    stage6.enableMouseOver(24);
    createjs.Ticker.setFPS(lib_camyve.properties.fps);
    createjs.Ticker.addEventListener("tick", stage6);
    init7();
}

function init7() {
    canvas = document.getElementById("canvas_quantuduong");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad7);
    loader.addEventListener("complete", handleComplete7);
    loader.loadManifest(lib_quantuduong.properties.manifest);
}

function handleFileLoad7(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete7(evt) {
    exportRoot = new lib_quantuduong.QuanTuDuong();

    stage7 = new createjs.Stage(canvas);
    stage7.addChild(exportRoot);
    stage7.update();
    stage7.enableMouseOver(24);
    createjs.Ticker.setFPS(lib_quantuduong.properties.fps);
    createjs.Ticker.addEventListener("tick", stage7);
    init8();
}

function init8() {
    canvas = document.getElementById("canvas_cuclaccoc");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad8);
    loader.addEventListener("complete", handleComplete8);
    loader.loadManifest(lib_cuclaccoc.properties.manifest);
}

function handleFileLoad8(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete8(evt) {
    exportRoot = new lib_cuclaccoc.CucLacCoc();

    stage8 = new createjs.Stage(canvas);
    stage8.addChild(exportRoot);
    stage8.update();
    stage8.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_cuclaccoc.properties.fps);
    createjs.Ticker.addEventListener("tick", stage8);
    init9();
}

function init9() {
    canvas = document.getElementById("canvas_kimchamthamgia");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad9);
    loader.addEventListener("complete", handleComplete9);
    loader.loadManifest(lib_kimchamthamgia.properties.manifest);
}

function handleFileLoad9(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete9(evt) {
    exportRoot = new lib_kimchamthamgia.KimChamThamGia();

    stage9 = new createjs.Stage(canvas);
    stage9.addChild(exportRoot);
    stage9.update();
    stage9.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_kimchamthamgia.properties.fps);
    createjs.Ticker.addEventListener("tick", stage9);
    init10();
}

function init10() {
    canvas = document.getElementById("canvas_tugiatrang");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad10);
    loader.addEventListener("complete", handleComplete10);
    loader.loadManifest(lib_tugiatrang.properties.manifest);
}

function handleFileLoad10(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete10(evt) {
    exportRoot = new lib_tugiatrang.TuGiaTrang();

    stage10 = new createjs.Stage(canvas);
    stage10.addChild(exportRoot);
    stage10.update();
    stage10.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_tugiatrang.properties.fps);
    createjs.Ticker.addEventListener("tick", stage10);
    init11();
}

function init11() {
    canvas = document.getElementById("canvas_vanthusontrang");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad11);
    loader.addEventListener("complete", handleComplete11);
    loader.loadManifest(lib_vanthusontrang.properties.manifest);
}

function handleFileLoad11(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete11(evt) {
    exportRoot = new lib_vanthusontrang.VanThuSonTrang();

    stage11 = new createjs.Stage(canvas);
    stage11.addChild(exportRoot);
    stage11.update();
    stage11.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_vanthusontrang.properties.fps);
    createjs.Ticker.addEventListener("tick", stage11);
    init12();
}

function init12() {
    canvas = document.getElementById("canvas_vocanmon");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad12);
    loader.addEventListener("complete", handleComplete12);
    loader.loadManifest(lib_vocanmon.properties.manifest);
}

function handleFileLoad12(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete12(evt) {
    exportRoot = new lib_vocanmon.VoCanMon();

    stage12 = new createjs.Stage(canvas);
    stage12.addChild(exportRoot);
    stage12.update();
    stage12.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_vocanmon.properties.fps);
    createjs.Ticker.addEventListener("tick", stage12);
    init13();
}

function init13() {
    canvas = document.getElementById("canvas_dihoacung");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad13);
    loader.addEventListener("complete", handleComplete13);
    loader.loadManifest(lib_dihoacung.properties.manifest);
}

function handleFileLoad13(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete13(evt) {
    exportRoot = new lib_dihoacung.DiHoaCung();

    stage13 = new createjs.Stage(canvas);
    stage13.addChild(exportRoot);
    stage13.update();
    stage13.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_dihoacung.properties.fps);
    createjs.Ticker.addEventListener("tick", stage13);
    init14();
}

function init14() {
    canvas = document.getElementById("canvas_daohoadao");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad14);
    loader.addEventListener("complete", handleComplete14);
    loader.loadManifest(lib_daohoadao.properties.manifest);
}

function handleFileLoad14(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete14(evt) {
    exportRoot = new lib_daohoadao.DaoHoaDao();

    stage14 = new createjs.Stage(canvas);
    stage14.addChild(exportRoot);
    stage14.update();
    stage14.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_daohoadao.properties.fps);
    createjs.Ticker.addEventListener("tick", stage14);
    init15();
}

function init15() {
    canvas = document.getElementById("canvas_langkhach");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad15);
    loader.addEventListener("complete", handleComplete15);
    loader.loadManifest(lib_langkhach.properties.manifest);
}

function handleFileLoad15(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete15(evt) {
    exportRoot = new lib_langkhach.LangKhach();

    stage15 = new createjs.Stage(canvas);
    stage15.addChild(exportRoot);
    stage15.update();
    stage15.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_langkhach.properties.fps);
    createjs.Ticker.addEventListener("tick", stage15);
    init16();
}

function init16() {
    canvas = document.getElementById("canvas_truongphongtieucuc");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad16);
    loader.addEventListener("complete", handleComplete16);
    loader.loadManifest(lib_truongphongtieucuc.properties.manifest);
}

function handleFileLoad16(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete16(evt) {
    exportRoot = new lib_truongphongtieucuc.TruongPhongTieuCuc();

    stage16 = new createjs.Stage(canvas);
    stage16.addChild(exportRoot);
    stage16.update();
    stage16.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_truongphongtieucuc.properties.fps);
    createjs.Ticker.addEventListener("tick", stage16);
    init17();
}

function init17() {
    canvas = document.getElementById("canvas_huyetdaomon");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad17);
    loader.addEventListener("complete", handleComplete17);
    loader.loadManifest(lib_huyetdaomon.properties.manifest);
}

function handleFileLoad17(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete17(evt) {
    exportRoot = new lib_huyetdaomon.HuyetDaoMon();

    stage17 = new createjs.Stage(canvas);
    stage17.addChild(exportRoot);
    stage17.update();
    stage17.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_huyetdaomon.properties.fps);
    createjs.Ticker.addEventListener("tick", stage17);
    init18();
}

function init18() {
    canvas = document.getElementById("canvas_hoason");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad18);
    loader.addEventListener("complete", handleComplete18);
    loader.loadManifest(lib_hoason.properties.manifest);
}

function handleFileLoad18(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete18(evt) {
    exportRoot = new lib_hoason.HoaSon();

    stage18 = new createjs.Stage(canvas);
    stage18.addChild(exportRoot);
    stage18.update();
    stage18.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_hoason.properties.fps);
    createjs.Ticker.addEventListener("tick", stage18);
    init19();
}

function init19() {
    canvas = document.getElementById("canvas_niemlaba");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad19);
    loader.addEventListener("complete", handleComplete19);
    loader.loadManifest(lib_niemlaba.properties.manifest);
}

function handleFileLoad19(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete19(evt) {
    exportRoot = new lib_niemlaba.NiemLaba();

    stage19 = new createjs.Stage(canvas);
    stage19.addChild(exportRoot);
    stage19.update();
    stage19.enableMouseOver(24);
    createjs.Ticker.setFPS(lib_niemlaba.properties.fps);
    createjs.Ticker.addEventListener("tick", stage19);
    init20();
}

function init20() {
    canvas = document.getElementById("canvas_thanthuycung");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad20);
    loader.addEventListener("complete", handleComplete20);
    loader.loadManifest(lib_thanthuycung.properties.manifest);
}

function handleFileLoad20(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete20(evt) {
    exportRoot = new lib_thanthuycung.ThanThuyCung();

    stage20 = new createjs.Stage(canvas);
    stage20.addChild(exportRoot);
    stage20.update();
    stage20.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_thanthuycung.properties.fps);
    createjs.Ticker.addEventListener("tick", stage20);
    init21();
}

function init21() {
    canvas = document.getElementById("canvas_como");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad21);
    loader.addEventListener("complete", handleComplete21);
    loader.loadManifest(lib_como.properties.manifest);
}

function handleFileLoad21(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleComplete21(evt) {
    exportRoot = new lib_como.CoMo();

    stage21 = new createjs.Stage(canvas);
    stage21.addChild(exportRoot);
    stage21.update();
    stage21.enableMouseOver(24);

    createjs.Ticker.setFPS(lib_como.properties.fps);
    createjs.Ticker.addEventListener("tick", stage21);
    init22();
}

function init22() {
    canvas = document.getElementById("canvas_button");
    images = images || {};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoadbtn);
    loader.addEventListener("complete", handleCompletebtn);
    loader.loadManifest(lib_btn.properties.manifest);
}

function handleFileLoadbtn(evt) {
    if (evt.item.type == "image") {
        images[evt.item.id] = evt.result;
    }
}

function handleCompletebtn(evt) {
    exportRoot = new lib_btn.Taigame();

    stagebutton = new createjs.Stage(canvas);
    stagebutton.addChild(exportRoot);
    stagebutton.update();
    stagebutton.enableMouseOver(24);
    createjs.Ticker.setFPS(lib_btn.properties.fps);
    createjs.Ticker.addEventListener("tick", stagebutton);
}