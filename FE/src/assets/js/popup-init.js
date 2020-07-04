  
//Hàm thực hiện fade popup
function FadePopup(obj){
        //Lấy đối tượng popup trong href đưa vào biến
        var loginBox = $(obj).attr('href');
        //Hiển thị popup
        $(loginBox).fadeIn(300);
        //Set the center alignment padding + border see css style
        //Giá trị 24 là do border
        var popMargTop = ($(loginBox).height() + 24) / 2; 
        var popMargLeft = ($(loginBox).width() + 24) / 2; 
        //Giá trị vị trí xuất hiện dựa vào top: 50% left: 50%
        $(loginBox).css({ 
                'margin-top' : -popMargTop,
                'margin-left' : -popMargLeft
        });
        // Thêm vào mặt nạ ở trên popup
        $('body').append('<div id="mask"></div>');
        $('#mask').fadeIn(300);
}

$(document).ready(function() {
                //Gọi popup mỗi lần nạp trang
               // FadePopup('a.login-window');
                //Gọi popup khi click
                $('a.login-window').click(function(){
                        FadePopup(this);
                });
                // Khi click vào close hoặc layer mark thì close
                $('a.close, #mask, #content-popup a').live('click', function() { 
                $('#mask , .login-popup').fadeOut(300 , function() {
                        $('#mask').remove();  
                }); 
                        //return false;
                });
});        
       