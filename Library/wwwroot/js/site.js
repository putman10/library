 $(document).ready(function() {
                var $fields = $('#fields');
                $('#btnAddField').click(function(e) {
                    e.preventDefault();
                    $('<input type="text" class="form-control" name="authorFields" /><br/>').appendTo($fields);
                });

document.getElementById('patronLogin').patron.onchange = function() {
    var newaction = "patrons/" + this.value + "/details";
    document.getElementById('patronLogin').action = newaction;
};
            });

