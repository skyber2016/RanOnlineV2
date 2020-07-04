(function( $, undefined ) {
	var ACTIVE_CLASS = "ActiveBanner";
	$.widget( "ui.fadegallery", {
		options:{
			control_event: "click",
			auto_play: false,
			delay: 2, //by default : each image can be viewed in 2 second
			control: undefined,
			next_btn: undefined,
			prev_btn: undefined,
			play_backward: false,
			cbFunction: undefined
		},
		_create: function() {
			var self = this,
				options = self.options,
				el = self.element;

			this.list = el;

			this.list_items = el.find("> li");

			this.control_items = options.control.find("li");

			this.current_active_index;

			this.onAnimate = false;

			this.list_items.each(function (index) { //init state
				var item = jQuery(this);

				if ( item.hasClass(ACTIVE_CLASS) ) {
					self.current_active_index = index;
				}
			});

			if ( self.options.cbFunction != undefined ) {
				self.options.cbFunction(self.current_active_index);
			}

			this.control_items.eq(self.current_active_index).addClass(ACTIVE_CLASS);
									
			//binding event
			if ( options.control != undefined ) {
				this.list_items.hover(function(){
					self._clearTimer();
				},function(){					
					if ( options.auto_play ) { self._autoPlay(); }
				});
				this.control_items.each(function (index) {
					var item = jQuery(this);
					item.bind(options.control_event, function () {
						if (!item.hasClass(ACTIVE_CLASS) ) {
							self.onAnimate = true;
							self.gotoSlide(index);
						}
						self._clearTimer();
						return false;
					});
					item.bind("mouseout", function () {
						if ( options.auto_play ) { self._autoPlay(); }
					});
				});
			}

			if ( options.next_btn != undefined ) { //next
				options.next_btn.bind("click", function () {
					if ( !self.onAnimate ) {
						self._clearTimer();
						self.onAnimate = true;
						self.next();
					}

					return false;
				});
			}

			if ( options.prev_btn != undefined ) { //prev
				options.prev_btn.bind("click", function () {
					if ( !self.onAnimate ) {
						self._clearTimer();
						self.onAnimate = true;
						self.prev();
					}

					return false;
				});
			}

			if ( options.auto_play ) { 
				self._autoPlay(); //enable autoplay
			}
		},

		/*
		*  name : _clear
		*  arguments: 
		*  return: void
		*  description: clear current active and return to no 'active' state
		*/
        _clear: function () {
            this.list_items.eq(this.current_active_index).removeClass(ACTIVE_CLASS);
			this.control_items.eq(this.current_active_index).removeClass(ACTIVE_CLASS);
            this.current_active_index = undefined;
        },

		/*
		*  name : _autoPlay
		*  arguments: 
		*  return: void
		*  description: autoplay
		*/
		_autoPlay: function () {
			var self = this;
			this.timer = setInterval(function () {
				self.onAnimate = true;
				if ( !self.options.play_backward ) {
					if ( self.current_active_index == self.list_items.length-1 ) { //current at the end of list
						self.gotoSlide(0);
					}
					else {
						self.gotoSlide(self.current_active_index+1);
					}
				}
				else {
					if ( self.current_active_index == 0 ) { //current at the begin of list
						self.gotoSlide(self.list_items.length-1);
					}
					else {
						self.gotoSlide(self.current_active_index-1);
					}
				}
			}, this.options.delay*1000);
		},

		/*
		*  name : next
		*  arguments: 
		*  return: void
		*  description: slide to next image
		*/
		next: function () {
			if ( this.current_active_index == this.list_items.length-1 ) { //current at the end of list
				this.gotoSlide(0);
			}
			else {
				this.gotoSlide(this.current_active_index+1);
			}
		},

		/*
		*  name : prev
		*  arguments: 
		*  return: void
		*  description: slide to prev image
		*/
		prev: function () {
			if ( this.current_active_index == 0 ) { //current at the begin of list
				this.gotoSlide(this.list_items.length-1);
			}
			else {
				this.gotoSlide(this.current_active_index-1);
			}
		},

		/*
		*  name : gotoSlide
		*  arguments: Integer index
		*  return: void if index in range, false if out of range
		*  description: go to specific slide
		*/
		gotoSlide: function (index) {
			var self = this;
			this._swapSlides(this.current_active_index, index, function () {
				self.current_active_index = index;
				if ( self.options.cbFunction != undefined ) {
					self.options.cbFunction(index);
                }
			});
		},

		/*
		*  name : _swapSlides
		*  arguments: Integer old_index, Integer new_index, Function callback
		*  return: void
		*  description: swap 2 slides (change visible state)
		*/
		_swapSlides: function (old_index, new_index, callback) {
			var self = this;
			if ( old_index != undefined ) { self.control_items.eq(old_index).removeClass(ACTIVE_CLASS); } //control_items 
			
			if ( (/MSIE 6\.0/).test(navigator.userAgent) ) {
				try {
                    DD_belatedPNG.applyVML(self.control_items.eq(old_index).find("a").get(0));
                } catch (exp) {}
			}
			
			self.control_items.eq(new_index).addClass(ACTIVE_CLASS); //control_items
			
			if ( (/MSIE 6\.0/).test(navigator.userAgent) ) {
				try {
                    DD_belatedPNG.applyVML(self.control_items.eq(new_index).find("a").get(0));
                } catch (exp) {}
			}

			/*this.list_items.eq(new_index).css({
				opacity: 1
			});
            if ( old_index != undefined ) {
                this.list_items.eq(old_index).animate({
                    opacity: 0
                }, "normal", "swing", function () {
                    self.list_items.eq(old_index).removeClass(ACTIVE_CLASS);
                    self.list_items.eq(new_index).addClass(ACTIVE_CLASS);
                    self._internal_callback();
                    if ( callback != undefined ) {
                        callback(self);
                    }
                });
            }
            else {
                self.list_items.eq(new_index).addClass(ACTIVE_CLASS);
                self._internal_callback();
                if ( callback != undefined ) {
                    callback(self);
                }
            }*/
			this.list_items.eq(new_index).stop().animate({
				opacity: 1
			});
            if ( old_index != undefined ) {
                this.list_items.eq(old_index).stop().animate({
                    opacity: 0
                }, "normal", "swing", function () {
                   
                    
                    
                });
				self.list_items.eq(old_index).removeClass(ACTIVE_CLASS);
                self.list_items.eq(new_index).addClass(ACTIVE_CLASS);
				self._internal_callback();
				if ( callback != undefined ) {
                        callback(self);
                    }
				 
            }
            else {
                self.list_items.eq(new_index).addClass(ACTIVE_CLASS);
                self._internal_callback();
                if ( callback != undefined ) {
                    callback(self);
                }
            }
		},

		/*
		*  name : internal_callback
		*  arguments: no
		*  return: void
		*  description: callback
		*/
		_internal_callback: function () {
			this.onAnimate = false;
			if ( this.timer == null ) {
				if ( this.options.auto_play ) { this._autoPlay(); } 
			}
		},

		/*
		*  name : clearTimer
		*  arguments: no
		*  return: void
		*  description: callback
		*/
		_clearTimer: function () {
			clearInterval(this.timer);
			this.timer = null;
		}
	});
})(jQuery);