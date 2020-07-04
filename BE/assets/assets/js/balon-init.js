$(document).ready(function(){
	hide_tip();
	del_tip();
	timeout = setTimeout(function(){
		$('#balon-hide').css({'display' : 'none'});
		 $('#balon-show').css({'display' : 'block'})
		 var height = - ($('#container-balon').height() - 30);
		 $('#container-balon').animate({'bottom': height + 'px'},400);
	}, 10000);
	//clearTimeout(timeout);
	show_tip();	
});

function hide_tip(){
	 $('#balon-hide').click(function(){		
		 $(this).css({'display' : 'none'});
		 $('#balon-show').css({'display' : 'block'})
		 var height = - ($('#container-balon').height() - 30);
		 $('#container-balon').animate({'bottom': height + 'px'},400);
		
	 });
 }
function show_tip(){
	 $('#balon-show').click(function(){				
		 $(this).css({'display' : 'none'});
		 $('#balon-hide').css({'display' : 'block'})
		 $('#container-balon').animate({'bottom': '0px'},400);		
	 });
}
 function del_tip(){
	 $('#balon-delete').click(function(){		 
		 $('#container-balon').fadeOut(1000);
	 });
 }
 
       