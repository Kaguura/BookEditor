$(document).ready(function () {

    $('.ShowBtn').click(function () {
        n = $(this).attr('value');
        if (n == -1) {
            $('.modal-title').text('Add');
            $('input[name=submit]').val('Add');
        }
        else {
            $('.modal-title').text('Edit');
            $('input[name=submit]').val('Edit');
            $('input[name=n]').val(n);
            $('input[name=title]').val($(this).data('title'));
            $('input[name=author]').val($(this).data('author'));
            $('input[name=genre]').val($(this).data('genre'));
            $('input[name=old\\.Title]').val($(this).data('title'));
            $('input[name=old\\.Author]').val($(this).data('author'));
            $('input[name=old\\.Genre]').val($(this).data('genre'));
        }
        $('#ModalZK').modal('show');
    });
});