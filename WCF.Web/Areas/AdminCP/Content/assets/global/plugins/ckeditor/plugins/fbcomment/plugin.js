CKEDITOR.plugins.add('fbcomment', {
    icons: 'fbcomment',
    init: function (editor) {
        editor.addCommand('fbcomment', new CKEDITOR.dialogCommand('fbcommentDialog'));
        editor.ui.addButton('fbcomment', {
            label: 'Insert FB comment',
            command: 'fbcomment',
            toolbar: 'insert,0'
        });

        CKEDITOR.dialog.add('fbcommentDialog', this.path + 'dialogs/fbcomment.js');
    }
});