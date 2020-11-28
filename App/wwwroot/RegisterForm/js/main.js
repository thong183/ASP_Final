(function($) {
    var emailExp = new RegExp(/^\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i);

    function validate_email(email) {
        /* Define the recommended regular expression. */
        var emailExp = new RegExp(/^\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i);

        /* Test the email given against the expression and return the result. */
        return emailExp.test(email);
    }

    $( "#birth_date" ).datepicker({
        dateFormat: "mm - dd - yy",
        showOn: "both",
        buttonText : '<i class="zmdi zmdi-calendar-alt"></i>',
    });

    $('.add-info-link ').on('click', function() {
        $('.add_info').toggle( "slow" );
    });

    $('#country').parent().append('<ul class="list-item" id="newcountry" name="country"></ul>');
    $('#country option').each(function(){
        $('#newcountry').append('<li value="' + $(this).val() + '">'+$(this).text()+'</li>');
    });
    $('#country').remove();
    $('#newcountry').attr('id', 'country');
    $('#country li').first().addClass('init');
    $("#country").on("click", ".init", function() {
        $(this).closest("#country").children('li:not(.init)').toggle();
    });

    $('#city').parent().append('<ul class="list-item" id="newcity" name="city"></ul>');
    $('#city option').each(function(){
        $('#newcity').append('<li value="' + $(this).val() + '">'+$(this).text()+'</li>');
    });
    $('#city').remove();
    $('#newcity').attr('id', 'city');
    $('#city li').first().addClass('init');
    $("#city").on("click", ".init", function() {
        $(this).closest("#city").children('li:not(.init)').toggle();
    });

    $('#district').parent().append('<ul class="list-item" id="newdistrict" name="district"></ul>');
    $('#district option').each(function () {
        $('#newdistrict').append('<li value="' + $(this).val() + '">' + $(this).text() + '</li>');
    });
    $('#district').remove();
    $('#newdistrict').attr('id', 'district');
    $('#district li').first().addClass('init');
    $("#district").on("click", ".init", function () {
        $(this).closest("#district").children('li:not(.init)').toggle();
    });


    var CountryOptions = $("#country").children('li:not(.init)');
    $("#country").on("click", "li:not(.init)", function() {
        CountryOptions.removeClass('selected');
        $(this).addClass('selected');
        $("#country").children('.init').html($(this).html());
        CountryOptions.toggle('slow');
    });

    var CityOptions = $("#city").children('li:not(.init)');
    $("#city").on("click", "li:not(.init)", function() {
        CityOptions.removeClass('selected');
        $(this).addClass('selected');
        $("#city").children('.init').html($(this).html());
        CityOptions.toggle('slow');
    });

    var DictrictOptions = $("#district").children('li:not(.init)');
    $("#district").on("click", "li:not(.init)", function () {
        DictrictOptions.removeClass('selected');
        $(this).addClass('selected');
        $("#district").children('.init').html($(this).html());
        DictrictOptions.toggle('slow');
    });

    $.validator.addMethod(
        /* The value you can use inside the email object in the validator. */
        "regex",

        /* The function that tests a given string against a given regEx. */
        function (value, element, regexp) {
            /* Check if the value is truthy (avoid null.constructor) & if it's not a RegEx. (Edited: regex --> regexp)*/

            if (regexp && regexp.constructor != RegExp) {
                /* Create a new regular expression using the regex argument. */
                regexp = new RegExp(regexp);
            }

            /* Check whether the argument is global and, if so set its last index to 0. */
            else if (regexp.global) regexp.lastIndex = 0;

            /* Return whether the element is optional or the result of the validation. */
            return this.optional(element) || regexp.test(value);
        }
    );

    $('#signup-form').validate({
        rules : {
            NameFirst : {
                required: true,
            },
            NameLast : {
                required: true,
            },
            NameMiddle: {
                required: true,
            },
            Email : {
                required: true,
                email: true,
                regex: /^\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i
            },
            Password : {
                required: true
            },
            re_password : {
                required: true,
                equalTo: "#password"
            }
        },
        onfocusout: function(element) {
            $(element).valid();
        },
    });

    jQuery.extend(jQuery.validator.messages, {
        required: "",
        remote: "",
        email: "",
        url: "",
        date: "",
        dateISO: "",
        number: "",
        digits: "",
        creditcard: "",
        equalTo: ""
    });
})(jQuery);