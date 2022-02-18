import re
from django.core.exceptions import ValidationError


def validate_email(value):
    if re.fullmatch(
            r'\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b',
            value
    ):
        return value
    else:
        raise ValidationError("Invalidate email")
