from flask import Flask, render_template, request

app = Flask(__name__)

def calculate_bmi(weight, height):
    try:
        bmi = weight / (height ** 2)
        return round(bmi, 2), determine_bmi_category(bmi)
    except ZeroDivisionError:
        return None, "Height cannot be zero."
    except TypeError:
        return None, "Invalid input type. Please provide numbers."

def determine_bmi_category(bmi):
    if bmi < 18.5:
        return 'Underweight'
    elif bmi < 25:
        return 'Healthy weight'
    elif bmi < 30:
        return 'Overweight'
    else:
        return 'Obesity'

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/calculate', methods=['POST'])
def calculate():
    try:
        weight = float(request.form['weight'])
        height = float(request.form['height'])
        bmi, category = calculate_bmi(weight, height)
        return render_template('result.html', bmi=bmi, category=category)
    except ValueError:
        return "Invalid input. Please enter numeric values for weight and height."

if __name__ == '__main__':
    app.run(debug=True)
