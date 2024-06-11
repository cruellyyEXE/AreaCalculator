select pr.name, c.name
from products pr
left join dbo.product_categories pc on pr.id = pc.product_id
left join dbo.categories c on pc.category_id = c.id