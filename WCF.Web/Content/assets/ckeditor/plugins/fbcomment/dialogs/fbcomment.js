CKEDITOR.dialog.add('fbcommentDialog', function (editor) {
    return {
        title: 'FBComment Properties',
        minWidth: 400,
        minHeight: 200,
        contents: [
            {
                id: 'tab-basic',
                label: 'Basic Settings',
                elements: [
                    {
                        type: 'text',
                        id: 'div',
                        label: 'div',
                        //validate: CKEDITOR.dialog.validate.notEmpty("Abbreviation field cannot be empty.")
                    },
                    {
                        type: 'text',
                        id: 'data-href',
                        label: 'data-href',
                        validate: CKEDITOR.dialog.validate.notEmpty("Link field cannot be empty.")
                    }
                ]
            }
        ],
            
            
        
        
        //onOk: function () {
        //var dialog = this;

        //var div = editor.document.createElement('div');
        //div.setAttribute('class', 'fb-post');
        //div.setText(dialog.getValueOf('tab-basic', 'div'));

        //var id = dialog.getValueOf('tab-adv', 'data-href');
        //if (id)
        //    div.setAttribute('data-href', id);

        //editor.insertElement(div);

        //}
        onOk: function () {
        var dialog = this;

        var div = editor.document.createElement('div');
        div.setAttribute('class', 'fb-post');
        div.setText(dialog.getValueOf('tab-basic', 'div'));

        var id = dialog.getValueOf('tab-basic','data-href');
        if (id)
            div.setAttribute('data-href', id);

        editor.insertElement(div);

    }
    };
});