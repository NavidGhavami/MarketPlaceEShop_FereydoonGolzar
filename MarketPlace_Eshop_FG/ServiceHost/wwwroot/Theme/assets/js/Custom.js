
function ShowMessage(title, text, theme) {
    window.createNotification({
        closeOnClick: true,
        displayCloseButton: false,
        positionClass: 'nfc-bottom-right',
        showDuration: 7000,
        theme: theme !== '' ? theme : 'success',
    })({
        title: title !== '' ? title : 'اعلان',
        message: decodeURI(text)
    });
}

$(document).ready(function () {
    var editors = $("[ckeditor]");
    if (editors.length > 0) {
        $.getScript('/Theme/assets/js/ckeditor.js', function () {
            $(editors).each(function (index, value) {
                var id = $(value).attr('ckeditor');
                ClassicEditor.create(document.querySelector('[ckeditor="' + id + '"]'),
                    {
                        toolbar: {
                            items: [
                                'heading',
                                '|',
                                'bold',
                                'italic',
                                'link',
                                '|',
                                'fontSize',
                                'fontColor',
                                '|',
                                'imageUpload',
                                'blockQuote',
                                'insertTable',
                                'undo',
                                'redo',
                                'codeBlock'
                            ]
                        },
                        language: 'fa',
                        table: {
                            contentToolbar: [
                                'tableColumn',
                                'tableRow',
                                'mergeTableCells'
                            ]
                        },
                        licenseKey: '',
                        simpleUpload: {
                            // The URL that the images are uploaded to.
                            uploadUrl: '/Uploader/UploadImage'
                        }

                    })
                    .then(editor => {
                        window.editor = editor;
                    }).catch(err => {
                        console.error(err);
                    });
            });
        });
    }

    
});

function FillPageId(pageId) {
    $('#PageId').val(pageId);
    $('#filter-form').submit();
}

$('[main_category_checkbox]').on('change', function (e) {
    var isChecked = $(this).is(':checked');
    var selectedCategoryId = $(this).attr('main_category_checkbox');
    console.log(selectedCategoryId);
    if (isChecked) {
        $('#sub_categories_' + selectedCategoryId).slideDown(300);
    } else {
        $('#sub_categories_' + selectedCategoryId).slideUp(300);
        $('[parent-category-id="' + selectedCategoryId + '"]').prop('checked', false);
    }
});



$('#add_color_button').on('click', function (e) {

    e.preventDefault();
    var colorName = $('#product_color_name_input').val();
    var colorPrice = $('#product_color_price_input').val();

    if (colorName !== '' && colorPrice !== '') {
        var currentColorsCount = $('#list_of_product_colors tr');

        var index = currentColorsCount.length;


        var isExistsSelectedColor = $('[color-name-hidden-input][value="' + colorName + '"]');

        if (isExistsSelectedColor.lenght !== 0) {
            debugger;
            var colorNameNode = `<input type="hidden" value="${colorName}" name="ProductColors[${index}].ColorName" color-name-hidden-input="${colorName}-${colorPrice}">`;
            var colorPriceNode = `<input type="hidden" value="${colorPrice}" name="ProductColors[${index}].Price" color-price-hidden-input="${colorName}-${colorPrice}">`;

            $('#create_product_form').append(colorNameNode);
            $('#create_product_form').append(colorPriceNode);


            var colorTableNode = `
          <tr color-table-item="${colorName}-${colorPrice}">
          <td>${colorName}</td> 
          <td>${colorPrice}</td>  
          <td> <a class="btn btn-lg text-danger" style="float: none;" title="حذف رنگ" onclick="removeProductColor('${colorName}-${colorPrice}')">
          <svg xmlns="http://www.w3.org/2000/svg" style="width: 20px; height: 20px; margin-right: 25px;" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
          <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
          </svg>
          <i class="bi bi-trash-fill"></i>
          </a>
          </td>
          </tr>`;
            $('#list_of_product_colors').append(colorTableNode);

            $('#product_color_name_input').val('');
            $('#product_color_price_input').val('');
        } else {
            ShowMessage('اخطار', 'رنگ وارد شده تکراری می باشد', 'warning');
            $('#product_color_name_input').val('').focus();
            $('#product_color_price_input').val('');
        }

    } else {
        ShowMessage('اخطار', 'لطفا نام رنگ و قیمت آن را به درستی وارد نمایید', 'warning');
    }

});

function removeProductColor(index) {
    $('[color-name-hidden-input="' + index + '"]').remove();
    $('[color-price-hidden-input="' + index + '"]').remove();
    $('[color-table-item="' + index + '"]').remove();
    reOrderProductColorHiddenInputs();
}

function reOrderProductColorHiddenInputs() {
    var hiddenColors = $('[color-name-hidden-input]');
    $.each(hiddenColors, function (index, value) {
        var hiddenColor = $(value);
        var colorId = $(value).attr('color-name-hidden-input');
        var hiddenPrice = $('[color-price-hidden-input="' + colorId + '"]');

        $(hiddenColor).attr('name', 'ProductColors[' + index + '].ColorName');
        $(hiddenPrice).attr('name', 'ProductColors[' + index + '].Price');
    });
}


$('#OrderBy').on('change',
    function () {
        $('#filter-form').submit();
    });