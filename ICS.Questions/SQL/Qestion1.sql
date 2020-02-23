SELECT * FROM Foods f
LEFT JOIN FoodStorages fs ON fs.FoodCode=f.FoodCode 
WHERE f.IsMeat=0 AND (fs.StorageMethod NOT IN ('Tin')OR fs.StorageMethod IS NULL) 