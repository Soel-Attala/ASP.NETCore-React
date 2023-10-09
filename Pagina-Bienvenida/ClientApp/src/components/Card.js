const Card = ({ title, paragraph, textbutton, children }) => {
    return (
        <div className="card text-center bg-dark mt-5">
            <div className="card-body">
                <h1 className="card-title text-info">{title}</h1>
                <p className="card-text text-light">{paragraph}</p>
                <a href="#" className="btn btn-danger">{textbutton}</a>
                {children}

            </div>
        </div>
    )
}

export default Card;

