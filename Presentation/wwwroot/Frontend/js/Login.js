document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("LoginForm").addEventListener('submit', async function (e) {
        e.preventDefault();

        console.log(document.getElementById("LoginForm"))

        const email = document.querySelector('input[name="Email"]').value;
        const password = document.querySelector('input[name="Password"]').value;

        console.log('Email:', email);
        console.log('Password:', password);

        const formData = new FormData();
        formData.append('Email', email.trim());
        formData.append('Password', password.trim());

        try {
            const response = await fetch('/Login/Signin', {
                method: 'POST',
                body: formData
            });

            if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);

            const contentType = response.headers.get('content-type');
            if (!contentType || !contentType.includes('application/json')) {
                throw new Error('Server did not return JSON');
            }

            const result = await response.json();

            if (result.success) {
                console.log('Email received:', result.emailReceived);
                localStorage.setItem('loggedInEmail', result.emailReceived);
                alert(result.message);
                window.location.href = '/Home/';
            } else {
                alert('Failed: ' + result.message);
            }
        } catch (err) {
            console.error('Login error:', err);
            alert('An unexpected error occurred.');
        }
    });
});