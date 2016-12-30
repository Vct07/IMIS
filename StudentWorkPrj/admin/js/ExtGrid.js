Ext.grid.TableGrid = function (table, config) {
     
        config = config || {};
        var cf = config.fields || [], ch = config.columns || [];
        table = Ext.get(table);
        if (table == null) return;
        var ct = table.insertSibling();
        var fields = [], cols = [];
        var headers = table.query("th");        
        for (var i = 0, h; h = headers[i]; i++) {
            var text = h.innerHTML;             
            var name = 'tcol-'+i;       
            fields.push(Ext.applyIf(cf[i] || {}, {
                name: name,
                mapping: 'td:nth('+(i+1)+')/@innerHTML'
            }));
 
            cols.push(Ext.applyIf(ch[i] || {}, {
                'header': text,
                'dataIndex': name,
                'width': h.offsetWidth-3,
                'tooltip': h.title,
                'sortable': false,
            
            }));
        }
   
        var ds  = new Ext.data.Store({
            reader: new Ext.data.XmlReader({
                record:'tbody tr'
            }, fields)
        });
           
        ds.loadData(table.dom);
   
        var cm = new Ext.grid.ColumnModel(cols);
  
        if(config.width || config.height){
            ct.setSize(config.width || 'auto', config.height || 'auto');
        }
        if(config.remove !== false){
            table.remove();
        }
        var width,height;
        height = 500;//table.dom.offsetHeight+65;
        width = table.dom.offsetWidth;//+23;
    
        var div = "<div id='" + table + "'></div>";//创建一个新的层用于显示GridPanel
    
        var el = Ext.getBody().createChild({ tag: 'div', id: table.id });
        //var GridID = "Order_Grid";
        //var el = document.getElementById(table.id);
    
        table.replace(el);
    
        if(config.netGrid){
            ds.data.removeAt(0);
        }
        var g=new Ext.grid.GridPanel({
            store:ds,
            cm:cm,        
            renderTo:'Order_Grid',//table.id,
            sm: new Ext.grid.RowSelectionModel(),
            height:height,     
            width: width,
            stripeRows: true
        }); 
};


