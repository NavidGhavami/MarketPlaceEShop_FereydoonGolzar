function open_waiting(selector = 'body') {
    $(selector).waitMe({
        effect: 'facebook',
        text: 'لطفا صبر کنید ...',
        bg: 'rgba(255,255,255,0.7)',
        color: '#000'
    });
}

function close_waiting(selector = 'body') {
    $(selector).waitMe('hide');
}

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
    var colorCode = $('#product_color_code_input').val();

    if (colorName !== '' && colorPrice !== '' && colorCode !== '') {
        var currentColorsCount = $('#list_of_product_colors tr');
        debugger;
        var index = currentColorsCount.length;


        var isExistsSelectedColor = $('[color-name-hidden-input][value="' + colorName + '"]');

        if (isExistsSelectedColor.lenght !== 0) {

            var colorNameNode = `<input type="hidden" value="${colorName}" name="ProductColors[${index}].ColorName" color-name-hidden-input="${colorName}-${colorPrice}">`;
            var colorPriceNode = `<input type="hidden" value="${colorPrice}" name="ProductColors[${index}].Price" color-price-hidden-input="${colorName}-${colorPrice}">`;
            var colorCodeNode = `<input type="hidden" value="${colorCode}" name="ProductColors[${index}].ColorCode" color-code-hidden-input="${colorName}-${colorPrice}">`;

            $('#create_product_form').append(colorNameNode);
            $('#create_product_form').append(colorPriceNode);
            $('#create_product_form').append(colorCodeNode);


            var colorTableNode = `
          <tr color-table-item="${colorName}-${colorPrice}">
          <td>${colorName}</td> 
          <td>${colorPrice}</td>  
          <td>
          <div style="border-radius: 50%; width:40px; height: 40px; background-color: ${colorCode}"></div>
          </td>
          <td> <a class="btn btn-lg text-danger" style="float: none;" title="حذف رنگ" onclick="removeProductColor('${colorName}-${colorPrice}')">
          <svg xmlns="http://www.w3.org/2000/svg" style="width: 20px; height: 20px; margin-right: 25px;" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
          <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
          </svg>
          <i class="bi bi-trash-fill"></i>
          </a>
          </td>
          </tr>`;
            $('#list_of_product_colors').append(colorTableNode);


        } else {
            ShowMessage('اخطار', 'رنگ وارد شده تکراری می باشد', 'warning');
            $('#product_color_name_input').val('');
            $('#product_color_price_input').val('');
            $('#product_color_code_input').val('');

            $('#product_color_name_input').val('').focus();
        }

    } else {
        ShowMessage('اخطار', 'لطفا نام رنگ و قیمت آن را به درستی وارد نمایید', 'warning');
    }

});


$('#add_feature_button').on('click', function (e) {

    e.preventDefault();
    var featureTitle = $('#product_feature_title_input').val();
    var featureValue = $('#product_feature_value_input').val();

    if (featureTitle !== '' && featureValue !== '') {

        var currentFeaturesCount = $('#list_of_product_features tr');
        var index = currentFeaturesCount.length;


        var isExistsSelectedFeature = $('[feature-title-hidden-input][value="' + featureTitle + '"]');

        if (isExistsSelectedFeature.lenght !== 0) {

            var featureTitleNode = `<input type="hidden" value="${featureTitle}" name="ProductFeatures[${index}].featureTitle" feature-title-hidden-input="${featureTitle}-${featureValue}">`;
            var featureValueNode = `<input type="hidden" value="${featureValue}" name="ProductFeatures[${index}].FeatureValue" feature-value-hidden-input="${featureTitle}-${featureValue}">`;

            $('#create_product_form').append(featureTitleNode);
            $('#create_product_form').append(featureValueNode);


            var featureTableNode = `
          <tr feature-table-item="${featureTitle}-${featureValue}">
          <td>${featureTitle}</td>
          <td>${featureValue}</td>
          <td> <a class="btn btn-lg text-danger" style="float: none;" title="حذف ویژگی" onclick="removeProductFeature('${featureTitle}-${featureValue}')">
          <svg xmlns="http://www.w3.org/2000/svg" style="width: 20px; height: 20px; margin-right: 25px;" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
          <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
          </svg>
          <i class="bi bi-trash-fill"></i>
          </a>
          </td>
          </tr>`;
            $('#list_of_product_features').append(featureTableNode);
            $('#product_feature_title_input').val('');
            $('#product_feature_value_input').val('');

        } else {
            ShowMessage('اخطار', 'ویژگی وارد شده تکراری می باشد', 'warning');
            $('#product_feature_title_input').val('');
            $('#product_feature_value_input').val('');

            $('#product_feature_title_input').val('').focus();
        }

    } else {
        ShowMessage('اخطار', 'لطفا نام ویژگی و مقدار آن را به درستی وارد نمایید', 'warning');
    }

});

function removeProductColor(index) {
    $('[color-name-hidden-input="' + index + '"]').remove();
    $('[color-price-hidden-input="' + index + '"]').remove();
    $('[color-code-hidden-input="' + index + '"]').remove();

    $('[color-table-item="' + index + '"]').remove();
    reOrderProductColorHiddenInputs();
}

function removeProductFeature(index) {
    $('[feature-title-hidden-input="' + index + '"]').remove();
    $('[feature-value-hidden-input="' + index + '"]').remove();

    $('[feature-table-item="' + index + '"]').remove();
    reOrderProductFeatureHiddenInputs();
}

function reOrderProductColorHiddenInputs() {
    var hiddenColors = $('[color-name-hidden-input]');
    $.each(hiddenColors, function (index, value) {

        var hiddenColor = $(value);
        var colorId = $(value).attr('color-name-hidden-input');
        var hiddenPrice = $('[color-price-hidden-input="' + colorId + '"]');
        var hiddenCode = $('[color-code-hidden-input="' + colorId + '"]');

        $(hiddenColor).attr('name', 'ProductColors[' + index + '].ColorName');
        $(hiddenPrice).attr('name', 'ProductColors[' + index + '].Price');
        $(hiddenCode).attr('name', 'ProductColors[' + index + '].ColorCode');
    });
}

function reOrderProductFeatureHiddenInputs() {
    var hiddenFeatures = $('[feature-title-hidden-input]');
    $.each(hiddenFeatures, function (index, value) {

        var hiddenFeature = $(value);
        var featureId = $(value).attr('feature-title-hidden-input');
        var hiddenFeatureValue = $('[feature-value-hidden-input="' + featureId + '"]');

        $(hiddenFeature).attr('name', 'ProductFeatures[' + index + '].featureTitle');
        $(hiddenFeatureValue).attr('name', 'ProductFeatures[' + index + '].FeatureValue');
    });
}


$('#OrderBy').on('change',
    function () {
        $('#filter-form').submit();
    });

function changeProductPriceBasedOnColor(colorId, priceOfColor, colorName) {

    var basePrice = parseInt($('#ProductBasePrice').val());

    var newPrice = (basePrice + priceOfColor).toLocaleString();

    $('.product-price').html((newPrice) + ' ' + 'تومان' + ' ( ' + colorName + ' ) ');
    $('#add_product_to_order_ProductColorId').val(colorId);
}

$('#number_of_products_in_basket').on('change',
    function (e) {
        var numberOfProduct = parseInt(e.target.value, 0);
        $('#add_product_to_order_Count').val(numberOfProduct);
    });


function onSuccessAddProductToOrder(result) {
    if (result.status === 'Success') {
        ShowMessage('اعلان موفقیت', result.message);

        setTimeout(function () {
            close_waiting();
        }, 3000);
    }

    else {
        ShowMessage('اعلان هشدار', result.message, 'warning');
    }

    location.reload();
}



$('#submitOrderForm').on('click', function () {
    $('#addProductToOrderForm').submit();
    open_waiting();
});

function removeProductFromOrder(detailId) {
    $.get('/user/remove-order-item/' + detailId).then(result => {
        location.reload();

    });
}

function checkDetailCount() {
    $('input[order-detail-count]').on('change', function (event) {
        open_waiting();
        var detailId = $(this).attr('order-detail-count');
        $.get('/user/change-detail-count/' + detailId + '/' + event.target.value).then(result => {
            $('#user-open-order-wrapper').html(result);
            setTimeout(function () {
                close_waiting();
                location.reload();
            }, 500);

        });

    });

}

function reloadPage() {
    location.reload();
}

checkDetailCount();

function wait_me() {

    open_waiting();

    setTimeout(function () {
        close_waiting();
    }, 3000);

}

var options = {
    url: function (phrase) {
        return `/seller/products-autocomplete?productName=${phrase}`;
    },
    getValue: function (element) {
        return element.title;
    },
    list: {
        match: {
            enabled: true
        },
        onSelectItemEvent: function () {
            var value = $("#ProductName").getSelectedItemData().id;

            $("#ProductId").val(value).trigger("change");
        }
    },
    theme: "plate-dark",


};








var $item = $('.carousel-item');
var $wHeight = $(window).height();
$item.eq(0).addClass('active');
$item.height($wHeight);
$item.addClass('full-screen');

$('.carousel img').each(function () {
    var $src = $(this).attr('src');
    var $color = $(this).attr('data-color');
    $(this).parent().css({
        'background-image': 'url(' + $src + ')',
        'background-color': $color
    });
    $(this).remove();
});

//$(window).on('resize', function () {
//    $wHeight = $(window).height();
//    $item.height($wHeight);
//});

$('.carousel').carousel({
    interval: 6000,
    pause: "false"
});





function readURL(input) {
    debugger;
    if (input.files && input.files[0]) {

        var reader = new FileReader();

        reader.onload = function (e) {
            $('.image-upload-wrap').hide();

            $('.file-upload-image').attr('src', e.target.result);
            $('.file-upload-content').show();

            $('.image-title').html(input.files[0].name);
        };

        reader.readAsDataURL(input.files[0]);

    } else {
        removeUpload();
    }
}

function removeUpload() {
    $('.file-upload-input').replaceWith($('.file-upload-input').clone());
    $('.file-upload-content').hide();
    $('.image-upload-wrap').show();
}
$('.image-upload-wrap').bind('dragover', function () {
    $('.image-upload-wrap').addClass('image-dropping');
});
$('.image-upload-wrap').bind('dragleave', function () {
    $('.image-upload-wrap').removeClass('image-dropping');
});


////////////////////////////Privacy and Policy Check////////////////////////////////////////

$(document).ready(function () {
    document.querySelector('#btn-register').disabled = true;
    $('[register_checkbox]').on('change', function (e) {
        
        var isChecked = $(this).is(':checked');

        if (isChecked) {
            document.querySelector('#btn-register').disabled = false;
        } else {
            document.querySelector('#btn-register').disabled = true;
        }
    });
});

