from django import forms

from .validators import validate_email


class EmailForm(forms.Form):
    email = forms.CharField(
        max_length=256,
        required=True,
        validators=[validate_email]
    )
