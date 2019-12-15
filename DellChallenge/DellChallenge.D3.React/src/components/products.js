import React, { Component } from "react";
import Validation from "../validation";
import { Link } from 'react-router-dom';

class ProductList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: []
    };
  }

  componentDidMount() {
    fetch("http://localhost:5000/api/products")
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            isLoaded: true,
            items: result
          });
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        error => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      );
  }

    delete(id) {
        fetch("http://localhost:5000/api/products/" + id, {
            method: "DELETE",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            },
            mode: "cors"
        })
            .then(res => res.json())
            .then(this.componentDidMount())
            .catch(err => console.log(err));
    }

  render() {
    const { error, isLoaded, items } = this.state;
    if (error) {
      return <p>Error: {error.message}</p>;
    } else if (!isLoaded) {
      return <p>Loading...</p>;
    } else {
      return (
          <ul>
            {items.map(item => (
              <div><li key={item.id}>
                {item.name} - {item.category}
                  </li>
                      <Link to={"/edit/" + item.id} className="btn btn-primary">Edit</Link>
                      <button onClick={() => this.delete(item.id)} className="btn btn-danger">Delete</button></div>
            ))}
          </ul>
      );
    }
  }
}

class Products extends Component {
  render() {
    return (
      <React.Fragment>
        <h1 className="display-4">Products</h1>
        <ProductList />
        <Validation />
      </React.Fragment>
    );
  }
}
export default Products;
