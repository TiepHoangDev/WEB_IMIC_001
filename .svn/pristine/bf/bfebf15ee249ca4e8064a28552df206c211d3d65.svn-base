var TableEditable = function () {

    var handleTable = function () {

        function restoreRow(oTable, nRow) {
            var aData = oTable.fnGetData(nRow);
            var jqTds = $('>td', nRow);

            for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
                oTable.fnUpdate(aData[i], nRow, i, false);
            }

            oTable.fnDraw();
        }

        function editRow(oTable, nRow) {
            var aData = oTable.fnGetData(nRow);
            var jqTds = $('>td', nRow);
            //jqTds[0].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[0] + '">';
            //jqTds[1].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[1] + '">';
            jqTds[2].innerHTML = '<textarea type="text" class="form-control w-100" rows = "3" >' + aData[2] + '</textarea>';
            //jqTds[3].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[3] + '">';
            jqTds[4].innerHTML = '<input type="text" class="form-control w-100" value="' + aData[4] + '">';
            //jqTds[5].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[5] + '">';
            jqTds[6].innerHTML = '<a class="edit" href="">Save</a>';
            jqTds[7].innerHTML = '<a class="cancel" href="">Cancel</a>';
        }

        function saveRow(oTable, nRow) {
            var jqTextArea = $('textarea', nRow);
            var jqInputs = $('input', nRow);
            //oTable.fnUpdate(jqInputs[0].value, nRow, 0, false);
            //oTable.fnUpdate(jqInputs[1].value, nRow, 1, false);
            oTable.fnUpdate(jqTextArea[0].value, nRow, 2, false);
            //oTable.fnUpdate(jqInputs[3].value, nRow, 3, false);
            oTable.fnUpdate(jqInputs[0].value, nRow, 4, false);
            //oTable.fnUpdate(jqInputs[5].value, nRow, 5, false);
            oTable.fnUpdate('<a class="edit" href="">Edit</a>', nRow, 6, false);
            oTable.fnUpdate('<a class="delete" href="">Delete</a>', nRow, 7, false);
            oTable.fnDraw();
            var content = jqTextArea[0].value;
            var likeCount = jqInputs[0].value;
            return [content, likeCount];
        }

        function cancelEditRow(oTable, nRow) {
            var jqInputs = $('input', nRow);
            //oTable.fnUpdate(jqInputs[0].value, nRow, 0, false);
            //oTable.fnUpdate(jqInputs[1].value, nRow, 1, false);
            oTable.fnUpdate(jqInputs[0].value, nRow, 2, false);
            //oTable.fnUpdate(jqInputs[3].value, nRow, 3, false);
            oTable.fnUpdate(jqInputs[1].value, nRow, 4, false);
            //oTable.fnUpdate(jqInputs[5].value, nRow, 5, false);
            oTable.fnUpdate('<a class="edit" href="">Edit</a>', nRow, 6, false);
            oTable.fnDraw();
        }

        var table = $('#sample_editable_1');

        var oTable = table.dataTable({

            // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
            // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js). 
            // So when dropdowns used the scrollable div should be removed. 
            //"dom": "<'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r>t<'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",

            "lengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],

            // Or you can use remote translation file
            //"language": {
            //   url: '//cdn.datatables.net/plug-ins/3cfcc339e89/i18n/Portuguese.json'
            //},

            // set the initial value
            "pageLength": 10,

            "language": {
                "lengthMenu": " _MENU_ records"
            },
            "columnDefs": [{ // set default column settings
                'orderable': true,
                'targets': [0]
            }, {
                "searchable": true,
                "targets": [0]
            }],
            "order": [
                [0, "asc"]
            ] // set first column as a default sort by asc
        });

        var tableWrapper = $("#sample_editable_1_wrapper");

        //tableWrapper.find(".dataTables_length select").select2({
        //    showSearchInput: true //hide search box with special css class
        //}); // initialize select2 dropdown

        var nEditing = null;
        var nNew = false;

        $('#sample_editable_1_new').click(function (e) {
            e.preventDefault();

            if (nNew && nEditing) {
                if (confirm("Previose row not saved. Do you want to save it ?")) {
                    saveRow(oTable, nEditing); // save
                    $(nEditing).find("td:first").html("Untitled");
                    nEditing = null;
                    nNew = false;

                } else {
                    oTable.fnDeleteRow(nEditing); // cancel
                    nEditing = null;
                    nNew = false;
                    
                    return;
                }
            }

            var aiNew = oTable.fnAddData(['', '', '', '', '', '']);
            var nRow = oTable.fnGetNodes(aiNew[0]);
            editRow(oTable, nRow);
            nEditing = nRow;
            nNew = true;
        });

        table.on('click', '.delete', function (e) {
            e.preventDefault();

            if (confirm("Bạn có chắc chắn xóa bình luận này ?") == false) {
                return;
            }
            var CommentReplyId = $(this).parent().parent().data('commentid');
            var deleteTr = $(this);
            $.ajax({
                url: 'Delete_VideoCommentReply',
                type: 'post',
                contentType: "application/json",
                data: JSON.stringify({ VideoCommentReplyId: CommentReplyId }),
                context: document.body,
                success: function (response) {
                    var nRow = deleteTr.parent().parent();
                    oTable.fnDeleteRow(nRow);
                    alert(response.message);
                }
            })
        });

        table.on('click', '.cancel', function (e) {
            e.preventDefault();
            if (nNew) {
                oTable.fnDeleteRow(nEditing);
                nEditing = null;
                nNew = false;
            } else {
                restoreRow(oTable, nEditing);
                nEditing = null;
            }
        });

        table.on('click', '.edit', function (e) {
            e.preventDefault();

            /* Get the row as a parent of the link that was clicked on */
            var nRow = $(this).parents('tr')[0];
            var CommentReplyId = $(this).parent().parent().data('commentid');
            var deleteTr = $(this);
            if (nEditing !== null && nEditing != nRow) {
                /* Currently editing - but not this row - restore the old before continuing to edit mode */
                restoreRow(oTable, nEditing);
                editRow(oTable, nRow);
                nEditing = nRow;
            } else if (nEditing == nRow && this.innerHTML == "Save") {
                /* Editing this row and want to save it */
                var edit = saveRow(oTable, nEditing);
                nEditing = null;
                var content = edit[0];
                var likeCount = edit[1];
                debugger
                $.ajax({
                    url: 'Save_VideoCommentReply',
                    type: 'post',
                    contentType: "application/json",
                    data: JSON.stringify({ VideoCommentReplyId: CommentReplyId, content: content, likeCount: likeCount }),
                    context: document.body,
                    success: function (response) {
                        alert(response.message);
                    }
                })
            } else {
                /* No edit in progress - let's start one */
                editRow(oTable, nRow);
                nEditing = nRow;
            }
        });
    }

    return {

        //main function to initiate the module
        init: function () {
            handleTable();
        }

    };

}();