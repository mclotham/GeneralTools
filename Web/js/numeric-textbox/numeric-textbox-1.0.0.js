/* numeric-textbox-1.0.0.js */
/* github.com/mclotham
/* requires jQuery */

(function($) {
  $.fn.inputFilter = function(inputFilter) {
    return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function() {
      if (inputFilter(this.value)) {
        this.oldValue = this.value;
        this.oldSelectionStart = this.selectionStart;
        this.oldSelectionEnd = this.selectionEnd;
      } else if (this.hasOwnProperty("oldValue")) {
        this.value = this.oldValue;
        this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
      }
    });
  };
}(jQuery));


// Install input filters.
$(".int-textbox").inputFilter(function(value) {
  return /^-?\d*$/.test(value); });
$(".uint-textbox").inputFilter(function(value) {
  return /^\d*$/.test(value); });
$(".float-textbox").inputFilter(function(value) {
  return /^-?\d*[.,]?\d*$/.test(value); });
$(".ufloat-textbox").inputFilter(function(value) {
    return /^\d*[.,]?\d*$/.test(value); });
$(".currency-textbox").inputFilter(function(value) {
  return /^-?\d*[.,]?\d{0,2}$/.test(value); });
$(".hex-textbox").inputFilter(function(value) {
  return /^[0-9a-f]*$/i.test(value); });
