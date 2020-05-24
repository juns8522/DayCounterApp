import React, { Component } from 'react';
import DatePicker from 'react-datepicker';

import 'react-datepicker/dist/react-datepicker.css';
import 'bootstrap/dist/css/bootstrap.min.css';

export class Home extends Component {
    constructor(props) {
        super(props)
        this.state = {
            fromDate: new Date(),
            toDate: new Date(),
            workingDays: 0
        };
    }

    handleChange = (id, date) => {
        if (id === 1) {
            this.setState({
                fromDate: date
            });
        }
        else if (id === 2) {
            this.setState({
                toDate: date
            });
        }
    }

    handleSubmit = e => {
        e.preventDefault();
        let date = this.state.fromDate;
        const fromDate = this.convertDateToString(date);
        date = this.state.toDate;
        const toDate = this.convertDateToString(date);

        this.getWorkingDays(fromDate, toDate)
    }

    convertDateToString(date) {
        var mm = date.getMonth() + 1;
        var dd = date.getDate();

        return [date.getFullYear(),
         (mm > 9 ? '' : '0') + mm,
         (dd > 9 ? '' : '0') + dd
        ].join('-');
    }

    async getWorkingDays(fromDate, toDate) {
        const response = await fetch(`https://localhost:44331/day/workingdays?from=${fromDate}&to=${toDate}`);

        if (response.ok) {
            const workingDays = await response.json();
            //console.log(data);
            this.setState({
                workingDays: workingDays
            })
        }
        else {
            this.setState({
                workingDays: 0
            })
        }
    }

    render() {
        return (
            <div className="container">
                <h3>Working Days: {this.state.workingDays} Days</h3>
                <form onSubmit={this.handleSubmit}>
                    <div className="form-group">
                        <label>From Date: </label>
                        <DatePicker
                            selected={this.state.fromDate}
                            onChange={date => this.handleChange(1, date)}
                            name="fromDate"
                            dateFormat="yyyy-MM-dd"
                        />
                    </div>

                    <div className="form-group">
                        <label>To Date: </label>
                        <DatePicker
                            selected={this.state.toDate}
                            onChange={date => this.handleChange(2, date)}
                            name="toDate"
                            dateFormat="yyyy-MM-dd"
                        />
                    </div>

                    <div className="form-group">
                        <button className="btn btn-primary">Get Working Days</button>
                    </div>
                </form>
            </div>
        );
    }
}
