from django.shortcuts import render, redirect, reverse

from .forms import EmailForm


def email_send(request):
    form = EmailForm(request.POST or None,)
    if form.is_valid():
        return render(
            request,
            'check_email/email_send.html', {'form': EmailForm()}
        )
    return render(request, 'check_email/email_send.html', {'form': form})
