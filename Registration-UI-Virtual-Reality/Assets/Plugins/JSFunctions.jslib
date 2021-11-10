mergeInto(LibraryManager.library, {

  CopyToClipboard: function (str) {
    str = Pointer_stringify(str);
    console.log(str);
    var textarea, result;
    try {
      textarea = document.createElement('textarea');
      textarea.setAttribute('readonly', true);
      textarea.setAttribute('contenteditable', true);
      textarea.style.position = 'fixed'; 
      textarea.value = str;
  
      document.body.appendChild(textarea);
  
      textarea.select();
  
      var range = document.createRange();
      range.selectNodeContents(textarea);
  
      var selectedText = window.getSelection();
      selectedText.removeAllRanges();
      selectedText.addRange(range);
  
      textarea.setSelectionRange(0, textarea.value.length);
      result = document.execCommand('copy');
    } catch (err) {
      console.error(err);
      result = null;
    } finally {
      document.body.removeChild(textarea);
    }
    // manual copy fallback using prompt
  if (!result) {
    result = prompt("Please copy this string manually:", str); // eslint-disable-line no-alert
    if (!result) {
      return false;
    }
  }
  return true;
},

openPage: function (url) {
        url = Pointer_stringify(url);
        console.log('Opening link: ' + url);
        window.open(url,'_blank');
      }
  }
);