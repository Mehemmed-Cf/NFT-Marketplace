document.addEventListener("DOMContentLoaded", () => {
    const forms = Array.from(document.querySelectorAll('.Subscribe-Form'));
    console.log('Attach subscriber handlers to', forms.length, 'forms');

    if (!forms.length) return;

    forms.forEach((form, idx) => {

        const btn = form.querySelector('button');

        if (btn && btn.type !== 'submit') {
            console.warn(`Form[${idx}] button type is "${btn.type}". Consider type="submit"`);
        }

        form.addEventListener('submit', async function (e) {
            console.log(`Form[${idx}] submit event fired`, e);

            e.preventDefault();
            e.stopImmediatePropagation();

            try {
                const emailInput = form.querySelector('input[name="Email"]');
                if (!emailInput) {
                    console.error(`Form[${idx}] has no input[name="Email"]`);
                    return;
                }

                const email = emailInput.value.trim();
                console.log(`Form[${idx}] email value: "${email}"`);
                if (!email) {
                    console.warn('Email empty');
                    return;
                }

                const formData = new FormData();
                formData.append('Email', email);

                form.classList.add('submitting');

                const response = await fetch('/Home/AddSubscriber', {
                    method: 'POST',
                    body: formData
                });

                console.log('Fetch finished. response.ok=', response.ok, 'status=', response.status);

                if (!response.ok) {
                    const text = await response.text();
                    console.error('Non-ok response body:', text);
                    alert('Network error: ' + response.status);
                    form.classList.remove('submitting');
                    return;
                }

                const result = await response.json();
                console.log('Server JSON:', result);

                if (result && result.success) {
                    const savedEmail = result.email ?? result.emailReceived ?? email;
                    //localStorage.setItem('subscribedEmail', savedEmail);
                    //alert('Subscribed: ' + savedEmail);
                } else {
                    const msg = result?.message ?? 'Unknown error';
                    alert('Failed: ' + msg);
                }
            } catch (err) {
                console.error('Submit error:', err);
                alert('Submit error, see console');
            } finally {
                form.classList.remove('submitting');
            }
        });
    });



    //document.querySelector('.Subscribe-Input').addEventListener('submit', async function (e) {
    //    e.preventDefault();
    //    console.log("coming from Subscriber js")

    //    const email = document.querySelector('input[name="Email"]').value;

    //    const formData = new FormData();
    //    formData.append('Email', email);

    //    const response = await fetch('/Home/AddSubscriber', {
    //        method: 'POST',
    //        body: formData
    //    });

    //    const result = await response.json();

    //    console.log(result);

    //    if (result.success) {
    //        console.log('Email received:', result.emailReceived);
    //        localStorage.setItem('subscribedEmail', result.emailReceived);
    //        alert('Email saved to localStorage from Sub Js!');
    //    } else {
    //        alert('Failed: ' + result.message);
    //    }
    //});

});
